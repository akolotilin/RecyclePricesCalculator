using MediatR;

namespace VmsInform.Business.Events
{
    public class NewsPublished : INotification
    {
        public long NewsId { get; set; }
    }
}
