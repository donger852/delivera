using FreeSql.DataAnnotations;

namespace DeliverService.Model
{
    public class Test
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }

        public string name { get; set; }
    }
     
}
