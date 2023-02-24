using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using kargo.Message;
using kargo.Model;
using kargo.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INavigationService = kargo.Services.Interface.INavigationService;

namespace kargo.ViewModel; 
public class UserSettingsWindowViewModel : ViewModelBase
{
    public User? Person { get; set; }
    private readonly INavigationService? _service;
    public UserSettingsWindowViewModel(INavigationService? service, IMessenger? messenger)
    {
        _service = service;
        messenger?.Register<ParameterMessage>(this, (user) =>
        {
            if (user != null)
            Person = user.Message as User;
        });
    }   
    public RelayCommand bGoBackClick => new(() => _service?.NavigateTo<UserMainWindowViewModel>());
   
}