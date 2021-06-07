using AA.Notify;

using NoteApp.UI.WpfApp.Services;

namespace NoteApp.UI.WpfApp.ViewModels
{
    public class BaseViewModel : NotifyPropertyChanged
    {
        public INavigationService NavigationService { get; set; }

        public BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
    }
}
