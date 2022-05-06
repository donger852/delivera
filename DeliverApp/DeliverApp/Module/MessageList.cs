using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverApp.Module
{
    public class MessageList
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

    }



    //public class Rootobject
    //{
    //    public Class1[] Property1 { get; set; }
    //}

    public class Class1
    {
        public string number { get; set; }
        public string name { get; set; }
    }

}
