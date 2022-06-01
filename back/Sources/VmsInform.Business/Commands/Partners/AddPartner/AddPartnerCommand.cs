using MediatR;
using System.Collections.Generic;
using VmsInform.Web.Dto.Partners;

namespace VmsInform.Business.Commands.Partners.AddPartner
{
    public class AddPartnerCommand : IRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Comment { get; set; }
        public string TaxNumber { get; set; }

        public IEnumerable<PartnerContactDto> Contacts { get; set; }
    }
}
