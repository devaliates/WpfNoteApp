using AA.Notify;

using NoteApp.UI.WpfApp.Models;
using NoteApp.UI.WpfApp.Services;

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace NoteApp.UI.WpfApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<NoteModel> Notes { get; private set; }

        public ICommand LogOutAsyncCommand { get; private set; }
        public ICommand RemoveAsyncCommand { get; private set; }
        public ICommand UpdateAsyncCommand { get; private set; }
        public ICommand AddAsyncCommand { get; private set; }

        public HomeViewModel(INavigationService navigationService, INoteService noteService, IAccountService accountService, AccountModel account)
            : base(navigationService)
        {
            Notes = new ObservableCollection<NoteModel>();
            BuildCommands(accountService, noteService);
            BuildEvents(accountService, noteService, account);
            noteService.GetAllAsync();
        }

        private void BuildCommands(IAccountService accountService, INoteService noteService)
        {
            LogOutAsyncCommand = new Command(async () =>
            {
                await accountService.LogoutAsync();
            });

            RemoveAsyncCommand = new Command<NoteModel>(async (noteModel) =>
            {
                await noteService.RemoveAsync(noteModel.Id);
            });

            UpdateAsyncCommand = new Command<NoteModel>(async (noteModel) =>
            {
                await noteService.UpdateAsync(noteModel);
            });

            AddAsyncCommand = new Command<String>(async (content) =>
            {
                await noteService.AddAsync(new NoteModel() { Id = Guid.NewGuid(), Content = content });
            });
        }

        private void BuildEvents(IAccountService accountService, INoteService noteService, AccountModel account)
        {
            noteService.GetAll += (sender, e) =>
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    Notes.Clear();

                    foreach (var note in e)
                        Notes.Add(note);
                });
            };

            noteService.Add += (sender, e) =>
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    Notes.Add(e);
                });
            };

            noteService.Remove += (sender, e) =>
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    Notes.Remove(Notes.FirstOrDefault(x => x.Id == e.Id));
                });
            };

            noteService.Update += (sender, e) =>
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    var note = Notes.FirstOrDefault(x => x.Id == e.Id);
                    if(note != null)
                    {
                        note.Content = e.Content;
                    }
                });
            };

            accountService.Logout += (sender, e) =>
            {
                account.Username = "";
                account.Password = "";
                NavigationService.Open("Login");
            };
        }
    }
}
