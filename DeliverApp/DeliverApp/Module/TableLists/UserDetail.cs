using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverApp.Module.TableLists
{
    public class UserDetail
    {
        public string UserName { get; set; }
        public string Url { get; set; }
        public string Password { get; set; }

        public int LoginType { get; set; }
    }


    public class Logintype
    {
        public static  int LogintypeName { get; set; }
    }
}
