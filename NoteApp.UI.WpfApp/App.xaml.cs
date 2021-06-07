using Microsoft.Extensions.DependencyInjection;

using NoteApp.UI.WpfApp.Models;
using NoteApp.UI.WpfApp.Services;
using NoteApp.UI.WpfApp.Services.AccountServices;
using NoteApp.UI.WpfApp.Services.NavigationServices;
using NoteApp.UI.WpfApp.Services.NoteServices;
using NoteApp.UI.WpfApp.ViewModels;
using NoteApp.UI.WpfApp.Views;

using System.Windows;

namespace NoteApp.UI.WpfApp
{
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public ServiceProvider ServiceProvider { get => serviceProvider; }

        protected override void OnStartup(StartupEventArgs e)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ServiceConfig(serviceCollection);
            serviceProvider = serviceCollection.BuildServiceProvider();

            base.OnStartup(e);

            MainWindow = serviceProvider.GetService<MainWindow>();
            MainWindow.Show();
        }

        private void ServiceConfig(ServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<MainWindow, MainWindow>()
                             .AddSingleton<MainViewModel, MainViewModel>()
                             .AddSingleton<LoginViewModel, LoginViewModel>()
                             .AddSingleton<HomeViewModel, HomeViewModel>()
                             .AddSingleton<INavigationService, NavigationService>()
                             .AddSingleton<IAccountService, LocalAccountService>()
                             .AddSingleton<INoteService, LocalNoteService>()
                             .AddSingleton<AccountModel, AccountModel>();
        }
    }
}
