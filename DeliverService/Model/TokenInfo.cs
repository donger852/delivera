using FreeSql.DataAnnotations;

namespace DeliverService.Model
{
    public class TokenInfo
    {
     //   public TokenInfo() { UserName = "jack.chen"; Pwd = "jack123456"; }

        [Column(IsIdentity = true, IsPrimary = true)]
        public string UserName { get; set; }

         [Column(IsIdentity = true, IsPrimary = true)]
        public string Url { get; set; }


    }
}
