using NoteApp.UI.WpfApp.ViewModels;

using System.Windows;
using System.Windows.Media.Animation;

namespace NoteApp.UI.WpfApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            this.DataContext = mainViewModel;

            Storyboard loginStoryBoard = TryFindResource("LoginStoryboard") as Storyboard;
            Storyboard homeStoryBoard = TryFindResource("HomeStoryboard") as Storyboard;

            mainViewModel.NavigationService.ActiveViewChanged += (sender, e) =>
            {
                switch (e)
                {
                    case "Login":
                        App.Current.Dispatcher.Invoke(() =>
                        {
                            BeginStoryboard(loginStoryBoard);
                        });
                        break;
                    case "Home":
                        App.Current.Dispatcher.Invoke(() =>
                        {
                            BeginStoryboard(homeStoryBoard);
                        });
                        
                        break;
                    default:
                        break;
                }
            };
        }
    }
}
