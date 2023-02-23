using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kargo.Services.Interface;
using GalaSoft.MvvmLight.Command;
using kargo.Model;
using kargo.Message;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace kargo.ViewModel
{
    public class EnteringWindowViewModel : ViewModelBase
    {
        private INavigationService? _navigationService;
        public string? Login { get; set; } = "";
        public string Password { get; set; } = "";
        public RelayCommand<PasswordBox> LoginCommand => new((Password) =>
        {
            if (DictionaryUsers.User!.ContainsKey(Login!))
            {

                if (DictionaryUsers.User[Login!].Password == Password.Password && Login != "admin" && Password.Password != "admin")
                {
                    _navigationService?.NavigateTo<UserMainWindowViewModel>(new ParameterMessage() { Message = DictionaryUsers.User[Login] });
                }
                else if (Login != "admin" && Password.Password != "admin") { MessageBox.Show("Login or password is incorrect!"); }


            }
            if (Login == "admin" && Password.Password == "admin")
            {
                _navigationService?.NavigateTo<AdminPanelViewModel>();
            }



        });

        public EnteringWindowViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public RelayCommand RegisterCommand
        {
            get => new(() =>
            {
                _navigationService?.NavigateTo<RegistrationWindowViewModel>();
            });

        }
    }
}
