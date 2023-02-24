using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using kargo.Services.Interface;
using GalaSoft.MvvmLight.Command;

namespace kargo.ViewModel;
public class OrderWindowViewModel : ViewModelBase
{
    private INavigationService? _service;

    public OrderWindowViewModel (INavigationService? service)
    {
        _service = service;
    }

    public RelayCommand bOrderToMainClick
    {
        get => new(() =>
        {
            _service?.NavigateTo<UserMainWindowViewModel>();
        });
    }
}