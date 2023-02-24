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
using System.Windows;
using kargo.Services.Classes;

namespace kargo.ViewModel
{
    public class RegistrationWindowViewModel : ViewModelBase
    {
        public User? User_ { get; set; } = new();
        public string? ConfirmPassword { get; set; }
        private readonly INavigationService? _service;

        public RegistrationWindowViewModel(INavigationService? service) 
        {
            _service = service;
        }

        public RelayCommand bLoginClick
        {
            get => new(() =>
                {
                    _service!.NavigateTo<EnteringWindowViewModel>();
            });
        }

        public RelayCommand bRegClick
        {
            get => new(() =>
            {
                if (!DictionaryUsers.User!.ContainsKey(User_!.UserName!))
                {
                    DictionaryUsers.User!.Add(User_!.FIN!, User_);
                    _service!.NavigateTo<UserMainWindowViewModel>( new ParameterMessage() { Message = User_ });
                    User_ = new();
                    var res = SerializationService<Dictionary<string, User>>.Serialization(DictionaryUsers.User!);
                    FileService.Write(res, "Data.json");
                }
                else MessageBox.Show("ОШИБКА,Возможно такой пользователь уже существует");

            });
        }  
    }
}
