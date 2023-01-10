using System.Collections.Generic;

namespace VmsInform.Web.Dto.Goods.Hierarchy
{
    public abstract class GoodsTreeNodeDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public abstract string Type { get; }
        public IEnumerable<GoodsTreeNodeDto> Childs { get; set; }
    }
}
