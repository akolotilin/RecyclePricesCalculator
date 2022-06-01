using System.Threading.Tasks;

namespace VmsInform.Common.Services
{
    public interface IPictureService
    {
        Task<byte[]> GetPicture(long id);
        Task<byte[]> GetThumbnail(long id);
        Task<long> AddPicture(byte[] data);        
    }
}
