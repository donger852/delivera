using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverApp.ViewModel
{
    public class CodeReplaceTipsViewModel
    {
        public CodeReplaceTipsViewModel(string tiptext)
        {

            TipText = tiptext;
        }
        public string TipText { get; set; }

        static CodeReplaceTipsViewModel(){
            TipTextList = new List<CodeReplaceTipsViewModel> {
                new CodeReplaceTipsViewModel("1.先输入坏标签条码，再输入新的标签条码" ),
                 new CodeReplaceTipsViewModel("1.先输入坏标签条码，再输入新的标签条码" ),
                  new CodeReplaceTipsViewModel("1.先输入坏标签条码，再输入新的标签条码" ),
                   new CodeReplaceTipsViewModel("1.先输入坏标签条码，再输入新的标签条码" ),
            };
        }



        public static IList<CodeReplaceTipsViewModel> TipTextList { private set; get; }
    }
}
