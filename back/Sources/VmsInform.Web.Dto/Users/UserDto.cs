namespace VmsInform.Web.Dto.Users
{
    public class UserDto
    {
        public long Id { get; set; }
        public string EMail { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
    }
}
