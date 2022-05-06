using FreeSql.DataAnnotations;

namespace DeliverService.Model
{
    public class Express
    {
        /// <summary>
        /// 快递编号
        /// </summary>
        [Column(IsIdentity = true, IsPrimary = true)]
        public string Id { get; set; }

        /// <summary>
        /// 快递名称
        /// </summary>
        public string Name { get; set; }
    }
}
