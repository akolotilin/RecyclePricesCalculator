using System.Collections.Generic;

namespace VmsInform.Web.Dto.Goods.Hierarchy
{
    public class GoodsTreeNodeGroupDto : GoodsTreeNodeDto
    {
        public override string Type => "group";

        public IEnumerable<GoodsTreeNodeDto> Childs { get; set; }
    }
}
