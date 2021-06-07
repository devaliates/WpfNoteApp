using Newtonsoft.Json;

using NoteApp.UI.WpfApp.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NoteApp.UI.WpfApp.Services.NoteServices
{
    public class LocalNoteService : INoteService
    {
        private const String notesDBPath = "NotesDB.json";

        public event EventHandler<IEnumerable<NoteModel>> GetAll;
        public event EventHandler<NoteModel> Add;
        public event EventHandler<NoteModel> Remove;
        public event EventHandler<NoteModel> Update;

        public LocalNoteService()
        {
            JsonLocalDatabaseCreate();
        }

        private void JsonLocalDatabaseCreate()
        {
            if (File.Exists(notesDBPath))
                return;

            var notes = new List<NoteModel>()
            {
                new NoteModel(){ Id = Guid.NewGuid(), Content = "Local Note 1"},
                new NoteModel(){ Id = Guid.NewGuid(), Content = "Local Note 2"},
                new NoteModel(){ Id = Guid.NewGuid(), Content = "Local Note 3"},
                new NoteModel(){ Id = Guid.NewGuid(), Content = "Local Note 4"},
                new NoteModel(){ Id = Guid.NewGuid(), Content = "Local Note 5"},
                new NoteModel(){ Id = Guid.NewGuid(), Content = "Local Note 6"},
                new NoteModel(){ Id = Guid.NewGuid(), Content = "Local Note 7"},
            };

            File.WriteAllText(notesDBPath, JsonConvert.SerializeObject(notes));
        }

        public async Task AddAsync(NoteModel note)
        {
            await Task.Run(() =>
            {
                try
                {
                    var notesJson = File.ReadAllText(notesDBPath);

                    var notes = JsonConvert.DeserializeObject<IList<NoteModel>>(notesJson);

                    note.Id = Guid.NewGuid();

                    notes.Add(note);

                    File.WriteAllText(notesDBPath, JsonConvert.SerializeObject(notes));

                    Add?.Invoke(this, note);
                }
                catch (Exception)
                {
                }
            });
        }

        public async Task GetAllAsync()
        {
            await Task.Run(() =>
            {
                try
                {
                    var notesJson = File.ReadAllText(notesDBPath);

                    var notes = JsonConvert.DeserializeObject<IList<NoteModel>>(notesJson);

                    GetAll?.Invoke(this, notes);
                }
                catch (Exception)
                {
                }
            });
        }

        public async Task RemoveAsync(Guid id)
        {
            await Task.Run(() =>
            {
                try
                {
                    var notesJson = File.ReadAllText(notesDBPath);

                    var notes = JsonConvert.DeserializeObject<IList<NoteModel>>(notesJson);

                    var note = notes.FirstOrDefault(x => x.Id == id);

                    notes.Remove(note);

                    File.WriteAllText(notesDBPath, JsonConvert.SerializeObject(notes));

                    Remove?.Invoke(this, note);
                }
                catch (Exception)
                {
                }
            });
        }

        public async Task UpdateAsync(NoteModel note)
        {
            await Task.Run(() =>
            {
                try
                {
                    var notesJson = File.ReadAllText(notesDBPath);

                    var notes = JsonConvert.DeserializeObject<IList<NoteModel>>(notesJson);

                    var dbNote = notes.FirstOrDefault(x => x.Id == note.Id);

                    dbNote.Content = note.Content;

                    File.WriteAllText(notesDBPath, JsonConvert.SerializeObject(notes));

                    Update?.Invoke(this, dbNote);
                }
                catch (Exception)
                {
                }
            });
        }
    }
}
