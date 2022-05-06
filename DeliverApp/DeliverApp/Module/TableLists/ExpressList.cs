using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverApp.Module.TableLists
{
    public class ExpressList
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Number { get; set; }
    }
}
