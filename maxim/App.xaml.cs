using GalaSoft.MvvmLight.Messaging;
using kargo.Services.Interface;
using kargo.Services.Classes;
using kargo.ViewModel;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;



namespace kargo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container? Container { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();

            MainStartup();

            base.OnStartup(e);
        }

        private void Register()
        {
            Container = new();

            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<INavigationService, NavigationService>();

            Container.RegisterSingleton<RegistrationWindowViewModel>();
            Container.RegisterSingleton<MainWindowViewModel>();
            Container.RegisterSingleton<UserMainWindowViewModel>();
            Container.RegisterSingleton<UserSettingsWindowViewModel>();
            Container.RegisterSingleton<EnteringWindowViewModel>();
            Container.RegisterSingleton<DeclareWindowViewModel>();
            Container.RegisterSingleton<OrderWindowViewModel>();
            Container.RegisterSingleton<AdminPanelViewModel>();



            Container.Verify();
        }

        private void MainStartup()
        {
            Window mainView = new MainWindow();

            mainView.DataContext = Container?.GetInstance<MainWindowViewModel>();

            mainView.ShowDialog();
        }

    }
}
