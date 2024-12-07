using SmartPlannerWebApi.Models;

namespace SmartPlannerWebApi.DataBase
{
    public interface INotesStorage
    {
        Task<List<Note>> GetNotesByUserIdAsync(Guid userId);
        Task AddNoteAsync(Note note);
        Task DeleteNoteAsync(Guid noteId);
        Task<Note> GetNoteByUserIdAsync(Guid userId);
        Task UpdateNoteAsync(Guid Id,Note newNote);
    }
}
