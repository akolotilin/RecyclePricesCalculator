using System;

namespace VmsInform.Web.Dto.News
{
    public class NewsDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishDate { get; set; }
        public bool IsUserAuthor { get; set; }
        public bool IsImportant { get; set; }
    }
}
