
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverApp.Module
{
    
    public class ClientLists
    {
        [PrimaryKey]
        public string Name { get; set; }
        public string Number { get; set; }
    }
}
