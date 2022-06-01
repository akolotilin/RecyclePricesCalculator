using MediatR;
using VmsInform.Web.Dto.Partners;

namespace VmsInform.Business.Commands.Partners.UpdatePriceOffer
{
    public class UpdatePriceOfferCommand : UpdatePriceOfferDto, IRequest<UpdatePriceOfferResultDto>
    {
        public long PartnerId { get; set; }
    }
}
