using System.Collections.Generic;

namespace VmsInform.Web.Dto.Goods._1C
{
    public class Good1CDto : Abstract1CItem
    {
        public string Comment { get; set; }
        public IEnumerable<Good1CSubItem> SubItems { get; set; }
    }
}
