using Microsoft.EntityFrameworkCore;
using SmartPlannerWebApi.Models;

namespace SmartPlannerWebApi.DataBase
{
    public class NotesStorage : INotesStorage
    {
        public MSSQLDBContext _context;
        public NotesStorage(MSSQLDBContext context)
        {
            this._context = context;
        }
        public async Task<bool> AddNoteAsync(Note note)
        {
            try
            {
            await _context.AddAsync(note);
            await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteNoteAsync(Guid noteId)
        {
            var note = await _context.Notes.FindAsync(noteId);
            if(note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<Note> GetNoteByUserIdAsync(Guid userId)
        {
            var note = await _context.Notes.FindAsync(userId);
            if(note != null)
                return note;
            return null;
        }

        public async Task<List<Note>> GetNotesByUserIdAsync(Guid userId)
        {
            var notes = new List<Note>();
            notes = await _context.Notes.Where(n => n.UserId == userId).ToListAsync();
            if (notes != null)
                return notes;
            return null;
        }

        public async Task<bool> UpdateNoteAsync(Guid Id, Note newNote)
        {
            var lastNote = await _context.Notes.FindAsync(Id);
            if (lastNote != null)
            {
                lastNote.UpdatedDate = DateTime.Now;
                lastNote.Description = newNote.Description;
                lastNote.Title = newNote.Title;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
