using FreeSql.DataAnnotations;

namespace DeliverService.Model
{
    public class TypeList
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        public string Typename { get; set; }
    }
}
