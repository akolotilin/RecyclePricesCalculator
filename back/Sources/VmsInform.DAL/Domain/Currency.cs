namespace VmsInform.DAL.Domain
{
    public class Currency : NamedObject
    {
        public string Code { get; set; }
        public decimal ExchangeRate { get; set; }
    }
}
