using NoteApp.UI.WpfApp.ViewModels;

using System;
using System.ComponentModel;

namespace NoteApp.UI.WpfApp.Services
{
    public interface INavigationService : INotifyPropertyChanged
    {
        public event EventHandler<String> ActiveViewChanged;

        public BaseViewModel ActiveView { get; set; }

        public void Open(String name);
    }
}
