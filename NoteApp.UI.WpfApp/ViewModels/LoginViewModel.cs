using AA.Notify;

using NoteApp.UI.WpfApp.Models;
using NoteApp.UI.WpfApp.Services;

using System;
using System.Windows.Input;

namespace NoteApp.UI.WpfApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private AccountModel account;
        public AccountModel Account { get => account; set => SetProperty(ref account, value); }

        public ICommand LoginAsyncCommand { get; private set; }

        public LoginViewModel(INavigationService navigationService, IAccountService accountService, INoteService noteService, AccountModel account)
            : base(navigationService)
        {
            Account = account;
            BuildEvents(accountService, noteService);
            BuildCommands(accountService);
        }

        private void BuildEvents(IAccountService accountService, INoteService noteService)
        {
            accountService.Login += (sender, e) =>
            {
                NavigationService.Open("Home");
            };
        }

        private void BuildCommands(IAccountService accountService)
        {
            LoginAsyncCommand = new Command(async () =>
            {
                await accountService.LoginAsync(Account.Username, Account.Password);
            });
        }
    }
}
