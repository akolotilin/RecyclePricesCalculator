using MediatR;

namespace VmsInform.Business.Events
{
    public class NewsUnPublished : INotification
    {
        public long NewsId { get; set; }
    }
}
