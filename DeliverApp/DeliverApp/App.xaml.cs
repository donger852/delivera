using DeliverApp.Core;
using DeliverApp.Module;
using DeliverApp.Module.TableLists;
using DeliverApp.Test;
using DeliverApp.View.LoginView;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliverApp
{
    public partial class App : Application
    {
        //private static ToDoContext database;
        //public static ToDoContext Instance
        //{
        //    get
        //    {
        //        if (database == null)
        //        {
        //            database = new ToDoContext(Constants.DatabasePath);
        //        }
        //        return database;
        //    }
        //}
        static Database database;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DeliverApp1.db3"));
                   // database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Server="));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();



              UserInfo.LoginType = 0;
             Logintype.LogintypeName = 0;
              MainPage = new NavigationPage(new LoginPage());
            //  MainPage = new NavigationPage(new DatadaseTestPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
