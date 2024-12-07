using SmartPlannerWebApi.DataBase;
using SmartPlannerWebApi.Models;

namespace SmartPlannerWebApi.StaticDataForTesting
{
    public class MemoryNotesStorage : INotesStorage
    {
        public List<Note> Notes { get; set; }

        public async Task AddNoteAsync(Note note)
        {
            Notes.Add(note);
        }

        public async Task DeleteNoteAsync(Guid noteId)
        {
            Notes.RemoveAll(n => n.Id == noteId);
        }

        public async Task EditNoteAsync(Guid id, Note newNote)
        {
            var lastNote = Notes.FirstOrDefault(n => n.Id == id);
            if (lastNote != null)
            {
                lastNote = newNote;
            }
        }

        public async Task<Note> GetNoteByUserIdAsync(Guid userId)
        {
            return Notes.FirstOrDefault(n => n.UserId == userId);
        }

        public async Task<List<Note>> GetNotesByUserIdAsync(Guid userId)
        {
            var notes = Notes.Where(n => n.UserId == userId).ToList();
            return notes.Count > 0 ? notes : null;
        }
    }
}
