using FreeSql.DataAnnotations;

namespace DeliverService.Model
{
    public class Location
    {
        /// <summary>
        /// 库位编号
        /// </summary>
        [Column(IsIdentity = true, IsPrimary = true)]
        public string Id { get; set; }

        /// <summary>
        /// 库位名称
        /// </summary>
        public string Name { get; set; }
    }
}
