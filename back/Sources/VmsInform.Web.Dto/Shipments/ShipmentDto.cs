using VmsInform.Web.Dto.Common;

namespace VmsInform.Web.Dto.Shipments
{
    public class ShipmentDto : BaseShipmentDto
    {
        public long Id { get; set; }
        public EditInfoDto EditInfo { get; set; }
        public string Partner { get; set; }
        public string Factory { get; set; }
    }
}
