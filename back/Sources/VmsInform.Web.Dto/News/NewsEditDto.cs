namespace VmsInform.Web.Dto.News
{
    public class NewsEditDto
    {
        public long? Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsImportant { get; set; }
    }
}
