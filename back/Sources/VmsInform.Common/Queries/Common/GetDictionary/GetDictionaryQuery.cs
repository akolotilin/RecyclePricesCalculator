using MediatR;
using System.Collections.Generic;
using VmsInform.Web.Dto.Common;

namespace VmsInform.Common.Queries.Common.GetDictionary
{
    public class GetDictionaryQuery<TEntity> : IRequest<IEnumerable<NamedObjectDto>>
    {
    }
}
