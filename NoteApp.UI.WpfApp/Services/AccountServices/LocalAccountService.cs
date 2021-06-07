using Newtonsoft.Json;

using NoteApp.UI.WpfApp.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NoteApp.UI.WpfApp.Services.AccountServices
{
    public class LocalAccountService : IAccountService
    {
        private const String accountDBPath = "AccountDB.json";

        public event EventHandler<AccountModel> Login;
        public event EventHandler Logout;

        public LocalAccountService()
        {
            JsonLocalDatabaseCreate();
        }

        private void JsonLocalDatabaseCreate()
        {
            if (File.Exists(accountDBPath))
                return;

            var accounts = new List<AccountModel>()
            {
                new AccountModel(){ Username = "ali", Password = "ates" },
                new AccountModel(){ Username = "cemal", Password = "keles" },
            };

            File.WriteAllText(accountDBPath, JsonConvert.SerializeObject(accounts));
        }

        public async Task LoginAsync(string username, string password)
        {
            await Task.Run(async () =>
            {
                try
                {
                    var accountsJson = await File.ReadAllTextAsync(accountDBPath);
                    var accounts = JsonConvert.DeserializeObject<List<AccountModel>>(accountsJson);

                    var account = accounts.FirstOrDefault(x => x.Username == username && x.Password == password);

                    if (account != null)
                    {
                        Login?.Invoke(this, account);
                    }
                }
                catch (Exception)
                {
                }
            });
        }

        public async Task LogoutAsync()
        {
            await Task.Run(() =>
            {
                Logout?.Invoke(this, null);
            });
        }
    }
}
