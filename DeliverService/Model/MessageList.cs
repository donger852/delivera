using FreeSql.DataAnnotations;

namespace DeliverService.Model
{
    public class MessageList
    {
       
        

        /// <summary>
        /// n
        /// </summary>
        [Column(IsIdentity = true, IsPrimary = true)]
        public string Id { get; set; }

       /// <summary>
       /// 名称
       /// </summary>
        public string Name { get; set; }
    }
}
