using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using kargo.Message;
using kargo.Model;
using kargo.Services.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace kargo.ViewModel
{
    public class AdminPanelViewModel:ViewModelBase
    {
        public User? User { get; set; }
        public Declarationcs? UserOrders { get; set; } = new();
        public ObservableCollection<Declarationcs?> UserOrdersList { get; set; }

        private readonly INavigationService? _navigationService;
        public string? User_key { get; set; } = "";
        public AdminPanelViewModel(INavigationService navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            messenger.Register<ParameterMessage>(this, param =>
            {
                if ((param is User) != null)
                {
                    User = param?.Message as User;
                }
            });
        }
        public RelayCommand BackButton
        {
            get => new(() =>
            {
                _navigationService?.NavigateTo<EnteringWindowViewModel>();
            });
        }
        public RelayCommand DeleteButton
        {
            get => new(() =>
            {
                UserOrdersList.Remove(UserOrders);
                DictionaryUsers.User[User_key].HistoryGoods.Remove(UserOrders);
            });
        }
        public RelayCommand SearchButton
        {
            get => new(() =>
            {
                if (DictionaryUsers.User.ContainsKey(User_key))
                {
                    UserOrdersList = DictionaryUsers.User![User_key].HistoryGoods!;
                }
                else
                {
                    MessageBox.Show("NOT USER");
                }
            });
        }
    }

}

