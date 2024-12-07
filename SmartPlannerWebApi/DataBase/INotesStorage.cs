using SmartPlannerWebApi.Models;

namespace SmartPlannerWebApi.DataBase
{
    public interface INotesStorage
    {
        Task<List<Note>> GetNotesByUserIdAsync(Guid userId);
        Task<bool> AddNoteAsync(Note note);
        Task<bool> DeleteNoteAsync(Guid noteId);
        Task<Note> GetNoteByUserIdAsync(Guid userId);
        Task<bool> UpdateNoteAsync(Guid Id,Note newNote);
    }
}
