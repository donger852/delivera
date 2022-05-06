using FreeSql.DataAnnotations;

namespace DeliverService.Model
{
    public class UserInfo
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public string UserName { get; set; }
        public string Url { get; set; }
        public string Password { get; set; }

        public int LoginType    { get; set; }
    }
}
