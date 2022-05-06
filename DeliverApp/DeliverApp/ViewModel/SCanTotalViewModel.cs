using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverApp.ViewModel
{
    public class SCanTotalViewModel
    {
        public SCanTotalViewModel(string timename,string totalcount,string successcount,string failurecount)
        {
            TimeName = timename;
            TotalCount = totalcount;
            SuccessCount = successcount;
            FailureCount = failurecount;
        }

        static SCanTotalViewModel()
        {
            DataCount = new List<SCanTotalViewModel>()
            {
                new SCanTotalViewModel("2022-03-16","13","0","13"),
                new SCanTotalViewModel("2022-03-15","12","2","10"),
                new SCanTotalViewModel("2022-03-14","12","1","11"),
                 new SCanTotalViewModel("2022-03-14","12","1","11"),
                  new SCanTotalViewModel("2022-03-14","12","1","11"),
                   new SCanTotalViewModel("2022-03-14","12","1","11"),
                    new SCanTotalViewModel("2022-03-14","12","1","11"),
                     new SCanTotalViewModel("2022-03-14","12","1","11"),
                      new SCanTotalViewModel("2022-03-14","12","1","11"),
                       new SCanTotalViewModel("2022-03-14","12","1","11"),
            };
        }

        public string TimeName { get; set; }
        public string TotalCount { get; set; }
        public string SuccessCount { get; set; }
        public string FailureCount { get; set; }


        public static List<SCanTotalViewModel> DataCount   { get; set; }

    }
}
