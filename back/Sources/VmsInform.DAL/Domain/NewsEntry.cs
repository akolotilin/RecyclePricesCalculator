using System;
using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DAL.Domain
{
    public class NewsEntry : VmsInformEntity
    {
        public DateTime DateTime { get; set; }

        public long AuthorId { get; set; }
        public virtual User Author { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }

        public bool IsImportant { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishDate { get; set; }

    }
}
