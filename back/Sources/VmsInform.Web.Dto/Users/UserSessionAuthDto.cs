namespace VmsInform.Web.Dto.Users
{
    public class UserSessionAuthDto
    {
        public long Id { get; set; }
        public string EMail { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
    }
}
