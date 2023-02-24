using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using kargo.Message;
using kargo.Model;
using kargo.Services.Interface;

namespace kargo.ViewModel;
public class UserMainWindowViewModel : ViewModelBase
{
    public User? Person { get; set; }
    private INavigationService? _service;

    public UserMainWindowViewModel(INavigationService? service , IMessenger messenger)
    {
        _service = service;
        messenger?.Register<ParameterMessage>(this, (user) =>
        {
            if(user != null)
            Person = user.Message as User;
        });
    }


    public RelayCommand bSettingsClick
    {
        get => new(() =>
        {
            _service?.NavigateTo<UserSettingsWindowViewModel>();
        });
    }

    public RelayCommand bOrderClick
    {
        get => new(() =>
        {
            _service?.NavigateTo<OrderWindowViewModel>();
        });
    }

    public RelayCommand bDeclareClick
    {
        get => new(() =>
        {
            _service?.NavigateTo<DeclareWindowViewModel>(new ParameterMessage() { Message = Person});
        });
    }

    public RelayCommand bMainToLogClick
    {
        get => new(() =>
        {
            _service?.NavigateTo<RegistrationWindowViewModel>();
        });
    }
}