using System;

namespace NoteApp.UI.WpfApp.Models
{
    public class NoteModel : BaseModel
    {
        private Guid id;
        public Guid Id { get => id; set => SetProperty(ref id, value); }

        private String content;
        public String Content { get => content; set => SetProperty(ref content, value); }
    }
}