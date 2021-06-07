
using AA.Notify;

using Microsoft.Extensions.DependencyInjection;

using NoteApp.UI.WpfApp.ViewModels;

using System;

namespace NoteApp.UI.WpfApp.Services.NavigationServices
{
    public class NavigationService : NotifyPropertyChanged, INavigationService
    {
        private ServiceProvider serviceProvider;

        private BaseViewModel activeView;
        public BaseViewModel ActiveView { get => activeView; set => SetProperty(ref activeView, value); }

        public event EventHandler<String> ActiveViewChanged;

        public NavigationService()
        {
            if (this.serviceProvider == null)
                ImportServiceProvier(((App)App.Current).ServiceProvider);
        }

        private void ImportServiceProvier(ServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Open(String name)
        {
            switch (name)
            {
                case "Home":
                    ActiveView = serviceProvider.GetService<HomeViewModel>();
                    break;
                case "Login":
                    ActiveView = serviceProvider.GetService<LoginViewModel>();
                    break;
                default:
                    break;
            }

            ActiveViewChanged?.Invoke(this, name);
        }
    }
}
