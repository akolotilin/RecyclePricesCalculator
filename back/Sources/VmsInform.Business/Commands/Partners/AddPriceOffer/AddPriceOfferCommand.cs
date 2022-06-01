using MediatR;
using VmsInform.Web.Dto.Partners;

namespace VmsInform.Business.Commands.Partners.AddPriceOffer
{
    public class AddPriceOfferCommand : UpdatePriceOfferDto, IRequest<UpdatePriceOfferResultDto>
    {
        public long PartnerId { get; set; }
    }
}
