using MediatR;
using VmsInform.Web.Dto.Goods;

namespace VmsInform.Business.Queries.Goods
{
    public class GetGoodQuery : IRequest<GoodEditDto>
    {
        public long GoodId { get; set; }
    }
}
