using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using kargo.Message;
using kargo.Model;
using kargo.Services.Classes;
using kargo.Services.Interface;
using kargo.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace kargo.ViewModel
{
    public class DeclareWindowViewModel : ViewModelBase
    {
        
        public User? Users { get; set; } = new();
        public Declarationcs Orders { get; set; } = new();

        private readonly INavigationService? _navigationService;
        public ObservableCollection<Declarationcs?> MyProduct { get; set; } = new();
        public DeclareWindowViewModel(INavigationService navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            messenger.Register<ParameterMessage>(this, param =>
            {
                Users = param?.Message as User;
            });
        }
        public RelayCommand BackButton
        {
            get => new(() =>
            {
                _navigationService?.NavigateTo<UserMainWindowViewModel>();

            });
        }
        public RelayCommand Add_Button
        {
            get => new(() =>
            {
                Users!.HistoryGoods!.Add(Orders!);
                Orders = new();
                _navigationService?.NavigateTo<UserMainWindowViewModel>(new ParameterMessage() { Message = Users });
            });
        }
    }
}