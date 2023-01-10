using MediatR;
using VmsInform.Web.Dto.Common;

namespace VmsInform.Business.Queries.Common
{
    public interface IPagedDataQuery<TDataItem> : IRequest<PagedDataDto<TDataItem>>
        where TDataItem : class
    {
        public int PageIndex { get; }
        public int PageSize { get; }
    }
}
