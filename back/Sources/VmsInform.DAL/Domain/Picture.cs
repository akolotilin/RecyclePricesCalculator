using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DAL.Domain
{
    public class Picture : VmsInformEntity
    {
        public virtual byte[] Data { get; set; }
    }
}
