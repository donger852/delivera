using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverApp.Module
{
    /// <summary>
    /// 仓库
    /// </summary>
    public class StorList
    {
        
        [PrimaryKey]
        public string Id { get; set; }
        public string Number { get; set; }
    }
}
