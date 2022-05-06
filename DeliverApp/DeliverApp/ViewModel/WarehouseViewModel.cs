using DeliverApp.Module;
using DeliverApp.View;
using DeliverApp.View.MenuSettingView;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DeliverApp.ViewModel
{
    public class WarehouseViewModel : BaseViewModel
    {
        //public  string OrderNum { get; set; }

        //public string Timename = DateTime.Now.ToString("yyyyMMdd");
        //public WarehouseViewModel()
        //{
        //    OrderNum = MachineCode + Timename + 0001;
        //    AutomaticCommand = new Command(() => AutomaticName_Clicked());
         

        //}

        //public Command AutomaticCommand { get; }
        //public Command SeleteClientsCommand { get; }

        //public Command SeleteStorCommand { get; }

      
        ///// <summary>
        ///// 机器代码
        ///// </summary>
        //public static string MachineCode = CompanySettingPage.MachineCodeDefaul;

        ///// <summary>
        ///// 自动生成
        ///// </summary>
        ///// <param name="senders"></param>
        ///// <param name="e"></param>
        //private void AutomaticName_Clicked()
        //{
 
        //    Random random = new Random();
        //    var num = random.Next(0, 9999);
        //    string result;
        //    if (num < 1000 && num >= 100)
        //    {
        //        result = "0" + num;
        //    }
        //    else if (num < 100 && num <= 10)
        //    {
        //        result = "00" + num;
        //    }
        //    else if (num < 10)
        //    {
        //        result = "000" + num;
        //    }
        //    else
        //    {
        //        result = num.ToString();
        //    }

        //    OrderNum = MachineCode + Timename + result;

        //}

        

    }
}
