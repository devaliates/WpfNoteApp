using NoteApp.UI.WpfApp.Models;

using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoteApp.UI.WpfApp.Services.NoteServices
{
    public class FakeNoteService : INoteService
    {
        private Random random;

        public event EventHandler<IEnumerable<NoteModel>> GetAll;
        public event EventHandler<NoteModel> Add;
        public event EventHandler<NoteModel> Remove;
        public event EventHandler<NoteModel> Update;

        public FakeNoteService()
        {
            random = new Random(DateTime.Now.Millisecond);
        }

        public async Task AddAsync(NoteModel note)
        {
            await Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(random.Next(500, 1000));

                    note.Id = Guid.NewGuid();
                    Add?.Invoke(this, note);
                }
                catch (Exception)
                {
                }
            });
        }

        public async Task GetAllAsync()
        {
            await Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(random.Next(500, 1000));

                    var notes = new List<NoteModel>();

                    notes.Add(new() { Id = Guid.NewGuid(), Content = "Note 1" });
                    notes.Add(new() { Id = Guid.NewGuid(), Content = "Note 2" });
                    notes.Add(new() { Id = Guid.NewGuid(), Content = "Note 3" });
                    notes.Add(new() { Id = Guid.NewGuid(), Content = "Note 4" });
                    notes.Add(new() { Id = Guid.NewGuid(), Content = "Note 5" });

                    GetAll?.Invoke(this, notes);
                }
                catch (Exception)
                {
                }
            });
        }

        public async Task RemoveAsync(Guid id)
        {
            await Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(random.Next(500, 1000));

                    Remove?.Invoke(this, new NoteModel() { Id = id });
                }
                catch (Exception)
                {
                }
            });
        }

        public async Task UpdateAsync(NoteModel note)
        {
            await Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(random.Next(500, 1000));

                    Update?.Invoke(this, note);
                }
                catch (Exception)
                {
                }
            });
        }
    }
}
