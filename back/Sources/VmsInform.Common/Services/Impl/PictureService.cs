using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Exceptions;
using VmsInform.DAL;
using VmsInform.DAL.Domain;

namespace VmsInform.Common.Services.Impl
{
    internal sealed class PictureService : IPictureService, IService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVmsInformRepository<Picture> _picturesRepository;

        public PictureService(IUnitOfWork unitOfWork, IVmsInformRepository<Picture> picturesRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _picturesRepository = picturesRepository ?? throw new ArgumentNullException(nameof(picturesRepository));
        }

        public async Task<long> AddPicture(byte[] data)
        {
            var picture = await _picturesRepository.AddAsync(new Picture { Data = data }, default(CancellationToken));
            await _unitOfWork.SaveAsync(default(CancellationToken));
            return picture.Id;
        }

        public async Task<byte[]> GetPicture(long id)
        {
            var picture = await _picturesRepository.GetAsync(id, default(CancellationToken));

            if (picture == null)
                throw new NotFoundException("Picture not found");

            return picture.Data;
        }

        public async Task<byte[]> GetThumbnail(long id)
        {
            var picture = await _picturesRepository.GetAsync(id, default(CancellationToken));

            if (picture == null)
                throw new NotFoundException("Picture not found");

            using (var stream = new MemoryStream(picture.Data))
                using(var outStream = new MemoryStream())
            {
                Image image = Image.Load(stream, out IImageFormat format);
                image.Mutate(a => a.Resize(new ResizeOptions
                {
                    Size = new Size(128, 128),
                    Mode = ResizeMode.Max
                }));

                //image.ExifProfile = null;
                //image.Quality = quality;
                image.Save(outStream, format);

                await outStream.FlushAsync();
                outStream.Position = 0;
                var outData = new byte[outStream.Length];
                await outStream.ReadAsync(outData, 0, outData.Length);
                return outData;
            }
        }
    }
}
