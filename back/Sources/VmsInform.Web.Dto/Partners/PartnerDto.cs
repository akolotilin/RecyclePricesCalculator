using System.Collections.Generic;
using VmsInform.Web.Dto.Common;

namespace VmsInform.Web.Dto.Partners
{
    public class PartnerDto : NamedObjectDto
    {
        public string Comment { get; set; }
        public string Address { get; set; }
        public bool IsBuyer { get; set; }
        public bool IsSeller { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
        public IEnumerable<PartnerContactDto> Contacts { get; set; }
    }
}
