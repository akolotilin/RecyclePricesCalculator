using System.Collections.Generic;

namespace VmsInform.Web.Dto.Goods._1C
{
    public class Group1CDto : Abstract1CItem
    {
        public IEnumerable<Group1CDto> SubGroups { get; set; }
        public IEnumerable<Good1CDto> Goods { get; set; }
    }
}
