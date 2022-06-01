using MediatR;
using System;
using VmsInform.Web.Dto.Goods;

namespace VmsInform.Business.Events
{
    public enum OfferAction
    {
        Added, Updated
    }

    public class OfferUpdatedEvent : INotification
    {
        public long PartnerId { get; set; }
        public long GoodId { get; set; }
        public long? FactoryId { get; set; }
        public decimal Price { get; set; }
        public CurrencyDto Currency { get; set; }
        public DateTime ValidThru { get; set; }
        public OfferAction Action { get; set; }
    }
}
