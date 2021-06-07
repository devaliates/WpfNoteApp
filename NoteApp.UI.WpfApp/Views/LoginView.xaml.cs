using NoteApp.UI.WpfApp.ViewModels;

using System.Windows;
using System.Windows.Controls;

namespace NoteApp.UI.WpfApp.Views
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var loginViewModel = this.DataContext as LoginViewModel;
            loginViewModel.Account.Password = (sender as PasswordBox).Password;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown(0);
        }
    }
}
