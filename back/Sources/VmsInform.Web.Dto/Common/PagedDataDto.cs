using System.Collections.Generic;

namespace VmsInform.Web.Dto.Common
{
    public class PagedDataDto<TDataItem>
        where TDataItem : class
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<TDataItem> Data { get; set; }
    }
}
