using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DAL.Domain
{
    public class GlobalSetting : VmsInformEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public string Order { get; set; }
        public string Domain { get; set; }
    }
}
