using NoteApp.UI.WpfApp.Services;

using System;

namespace NoteApp.UI.WpfApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            NavigationService.Open("Login");
        }
    }
}
