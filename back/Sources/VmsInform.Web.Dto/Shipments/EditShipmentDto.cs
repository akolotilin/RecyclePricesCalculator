namespace VmsInform.Web.Dto.Shipments
{
    public class EditShipmentDto : BaseShipmentDto
    {
        public long PartnerId { get; set; }
        public long FactoryId { get; set; }
        public long[] Pictures { get; set; }
    }
}
