using System;
using SmartPlannerWebApi.DataBase;
using SmartPlannerWebApi.Models;

namespace SmartPlannerWebApi.StaticDataForTesting
{
    public class MemoryNotesStorage : INotesStorage
    {
        public List<Note> Notes { get; set; } = new List<Note>();

        public async Task<bool> AddNoteAsync(Note note)
        {
            Notes.Add(note);
            return true;
        }

        public async Task<bool> DeleteNoteAsync(Guid noteId)
        {
            Notes.RemoveAll(n => n.Id == noteId);
            return true;
        }

        public async Task<bool> UpdateNoteAsync(Guid id, Note newNote)
        {
            var lastNote = Notes.FirstOrDefault(n => n.Id == id);
            if (lastNote != null)
            {
                lastNote.UpdatedDate = DateTime.Now;
                lastNote.Description = newNote.Description;
                lastNote.Title = newNote.Title;
                return true;
            }
            return false;
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
