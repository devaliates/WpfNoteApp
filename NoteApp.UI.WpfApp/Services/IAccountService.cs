using NoteApp.UI.WpfApp.Models;

using System;
using System.Threading.Tasks;

namespace NoteApp.UI.WpfApp.Services
{
    public interface IAccountService
    {
        public event EventHandler<AccountModel> Login;
        public event EventHandler Logout;

        public Task LoginAsync(String username, String password);
        public Task LogoutAsync();
    }
}
