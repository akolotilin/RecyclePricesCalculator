using VmsInform.Web.Dto.Common;

namespace VmsInform.Web.Dto.Factories
{
    public class FactoryDto : NamedObjectDto
    {
        public string Address { get; set; }
        public decimal MinGarbage { get; set; }
        public decimal MaxGarbage { get; set; }
        public string Comment { get; set; }
    }
}
