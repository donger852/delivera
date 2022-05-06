using DeliverApp.View.MenuSettingView;
using System;
using System.Collections.Generic;

namespace DeliverApp.ViewModel
{
    public class MenuSettingViewModel 
    {
        public MenuSettingViewModel (Type type,string title)
        {
            Type = type;
            Title = title;
        }
        public string Title { get; set; }
        public Type Type { get; set; }

        static   MenuSettingViewModel()
        {
            All = new List<MenuSettingViewModel> 
            { 
                new MenuSettingViewModel (typeof(CompanySettingPage),"公司设置"),
                new MenuSettingViewModel (typeof(DefaultSettingPage),"默认设置"),
                new MenuSettingViewModel (typeof(VerifySettingPage),"验证设置"),
                new MenuSettingViewModel (typeof(SystemSettingPage),"系统设置"),
                new MenuSettingViewModel (typeof(UpdatingPage),"数据更新"),
                new MenuSettingViewModel (typeof(UpdatingPage),"当前版本"),
                new MenuSettingViewModel (typeof(UpdatingPage),"清理数据"),
            };
            
        }
        public static IList<MenuSettingViewModel> All { private set; get; }

     

       
    }
}
