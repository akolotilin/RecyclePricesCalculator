using MediatR;
using VmsInform.Web.Dto.Goods;

namespace VmsInform.Business.Commands.Goods.UpdateGood
{
    public class UpdateGoodCommand : GoodEditDto, IRequest
    {
        public long GoodId { get; set; }
    }
}
