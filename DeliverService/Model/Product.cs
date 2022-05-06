using FreeSql.DataAnnotations;

namespace DeliverService.Model
{
    public class Product
    {
        /// <summary>
        /// 产品编号
        /// </summary>
        [Column(IsIdentity = true, IsPrimary = true)]
        public string Id { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }
    }
}
