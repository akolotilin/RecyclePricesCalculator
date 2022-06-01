using MediatR;
using VmsInform.Web.Dto.Goods;

namespace VmsInform.Business.Commands.Goods.AddGood
{
    public class AddGoodCommand : GoodEditDto, IRequest<long>
    {
    }
}
