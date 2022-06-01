using MediatR;
using System.Collections.Generic;
using VmsInform.Web.Dto.Common;

namespace VmsInform.Business.Queries.Partners.GetBuyers
{
    public class GetBuyersQuery : IRequest<IEnumerable<NamedObjectDto>>
    {
    }
}
