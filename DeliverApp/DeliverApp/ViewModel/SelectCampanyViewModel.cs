using DeliverApp.Module;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverApp.ViewModel
{
    public class SelectCampanyViewModel
    {
       
        public SelectCampanyViewModel(string url, string campanname)
        {
            CampanyName = campanname;
            Url = url;
           
           
        }

        public string CampanyName { get; set; }

        public string Url { get; set; }
       
       

        static SelectCampanyViewModel()
        {
            All = new List<SelectCampanyViewModel>
            {
                new SelectCampanyViewModel ("http://demo.hyxmt.cn","(白开水)"),
                new SelectCampanyViewModel ("http://demo.hyxmt.cn","(白开水)"),
                new SelectCampanyViewModel ("http://demo.hyxmt.cn","(白开水)")


            };
        }

        public static IList<SelectCampanyViewModel> All { private set; get; }

    }
}
