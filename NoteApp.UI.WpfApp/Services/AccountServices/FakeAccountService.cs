using NoteApp.UI.WpfApp.Models;

using System;
using System.Threading.Tasks;

namespace NoteApp.UI.WpfApp.Services.AccountServices
{
    public class FakeAccountService : IAccountService
    {
        private Random random;

        public event EventHandler<AccountModel> Login;
        public event EventHandler Logout;

        public FakeAccountService()
        {
            random = new Random(DateTime.Now.Millisecond);
        }

        public async Task LoginAsync(String username, String password)
        {
            await Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(random.Next(100, 1000));

                    if (username == "ali" && password == "ates")
                    {
                        Login?.Invoke(this, new AccountModel() { Username = "ali", Password = "ates" });
                    }
                }
                catch (Exception)
                {

                }
            });
        }

        public async Task LogoutAsync()
        {
            await Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(random.Next(100, 1000));

                    Logout?.Invoke(this, null);
                }
                catch (Exception)
                {
                }
            });
        }
    }
}
