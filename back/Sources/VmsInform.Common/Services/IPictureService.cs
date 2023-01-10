using System.Threading.Tasks;

namespace VmsInform.Common.Services
{
    public interface IPictureService
    {
        Task<byte[]> GetPicture(long id);
        Task<byte[]> GetThumbnail(long id, int size);
        Task<long> AddPicture(byte[] data);        
    }
}
