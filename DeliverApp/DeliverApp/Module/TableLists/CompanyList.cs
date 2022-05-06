using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverApp.Module.TableLists
{
    public class CompanyList
    {
        [PrimaryKey]
        public string CompanyCode { get; set; }
        public string Url { get; set; }

        public string CompanyName { get; set; }
       
        public string CompanyPassword { get; set; }
    }
}
