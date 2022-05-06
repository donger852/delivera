using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DeliverApp.ViewModel
{
    public class LoginViewModel : BaseViewModel,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string _url;
        public string _username;
        public string _password;
        public string _validatemsgtext;
        public string UserName
        { 
            get { return _username; }
            set { _username = value; OnPropertyChanged(nameof(UserName)); } 
        }
        
        public string Url
        {
            get { return _url; }
            set { _url = value; OnPropertyChanged(nameof(Url)); }
        }
       
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }
        
        public string ValidateMsgText
        {
            get { return _validatemsgtext; }
            set { _validatemsgtext = value; OnPropertyChanged(nameof(ValidateMsgText)); }
        }


        public LoginViewModel() {

            LoginBtn_Commmand = new Command(()=>OnLogin());
        }

        public void OnLogin() {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Url))
            {
                ValidateMsgText = "用户信息错误";


            }
            else { 
                
            }
        }


        #region Command
        public Command LoginBtn_Commmand { get; set; }
        #endregion
    }
}
