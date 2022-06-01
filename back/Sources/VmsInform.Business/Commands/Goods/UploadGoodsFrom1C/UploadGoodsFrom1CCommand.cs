using MediatR;
using System.Collections.Generic;
using VmsInform.Web.Dto.Goods._1C;

namespace VmsInform.Business.Commands.Goods.UploadGoodsFrom1C
{
    public class UploadGoodsFrom1CCommand : IRequest
    {
        public IEnumerable<Group1CDto> Groups { get; set; }
    }
}
