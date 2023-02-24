using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using kargo.Message;
using kargo.Model;
using kargo.Services.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kargo.ViewModel;

public class MainWindowViewModel : ViewModelBase
{
    public ViewModelBase? CurrentViewModel { get; set; }

    private readonly IMessenger _messenger;

    public MainWindowViewModel(IMessenger messenger)
    {
        CurrentViewModel = App.Container?.GetInstance<RegistrationWindowViewModel>();

        _messenger = messenger;

        _messenger.Register<NavigationMessage?>(this, message =>
        {
            var viewModel = App.Container?.GetInstance(message?.ViewModelType!) as ViewModelBase;
            CurrentViewModel = viewModel;
        });
    }

    public RelayCommand ExitClick => new(() => 
    {
        var res = SerializationService<Dictionary<string, User>>.Serialization(DictionaryUsers.User!);
        FileService.Write(res, "Data.json");
        App.Current.Shutdown();
    });
}