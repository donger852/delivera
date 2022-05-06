using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverApp.Module.TableLists
{
    public class Custormers
    {
        [PrimaryKey]
        public string Id { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string Name { get; set; }
    }
}
