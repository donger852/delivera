using FreeSql.DataAnnotations;

namespace DeliverService.Model
{
    public class Custormers
    {
        /// <summary>
        /// 客户编号
        /// </summary>
        [Column(IsIdentity = true, IsPrimary = true)]
        public string Id { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string Name { get; set; }
    }
}
