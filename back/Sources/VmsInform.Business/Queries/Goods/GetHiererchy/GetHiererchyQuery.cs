using MediatR;
using System.Collections.Generic;
using VmsInform.Web.Dto.Goods.Hierarchy;

namespace VmsInform.Business.Queries.Goods.GetHiererchy
{
    public class GetHiererchyQuery : IRequest<IEnumerable<GoodsTreeNodeDto>>
    {
    }
}
