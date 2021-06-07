using NoteApp.UI.WpfApp.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteApp.UI.WpfApp.Services
{
    public interface INoteService
    {
        public event EventHandler<IEnumerable<NoteModel>> GetAll;
        public event EventHandler<NoteModel> Add;
        public event EventHandler<NoteModel> Remove;
        public event EventHandler<NoteModel> Update;

        public Task GetAllAsync();
        public Task AddAsync(NoteModel note);
        public Task RemoveAsync(Guid id);
        public Task UpdateAsync(NoteModel note);
    }
}
