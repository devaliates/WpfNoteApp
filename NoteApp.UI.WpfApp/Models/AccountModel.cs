using System;

namespace NoteApp.UI.WpfApp.Models
{
    public class AccountModel : BaseModel
    {
        private String username;
        public String Username { get => username; set => SetProperty(ref username, value); }

        private String password;
        public String Password { get => password; set => SetProperty(ref password, value); }

    }
}
