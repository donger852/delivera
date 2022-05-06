using FreeSql.DataAnnotations;

namespace DeliverService.Model
{
    public class Store
    {
        /// <summary>
        /// 仓库编号
        /// </summary>
        [Column(IsIdentity = true, IsPrimary = true)]
        public string Id { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string Name { get; set; }
    }
}
