namespace VmsInform.Web.Dto.Products
{
    public enum ComponentType
    {
        Raw, Component
    }

    public class ProductComponentDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ComponentType Type { get; set; }
        public decimal Percentage { get; set; }
    }
}
