using MediatR;
using System.Collections.Generic;
using VmsInform.Web.Dto.Common;

namespace VmsInform.Business.Queries.Goods.GetGoodsByGroup
{
    public class GetGoodsByGroupQuery : IRequest<IEnumerable<NamedObjectDto>>
    {
        public long GroupId { get; set; }
    }
}
