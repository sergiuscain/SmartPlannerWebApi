using Microsoft.AspNetCore.Mvc;
using SmartPlannerWebApi.DataBase;
using SmartPlannerWebApi.Models;
using SmartPlannerWebApi.StaticDataForTesting;

namespace SmartPlannerWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]   //Доступ к контроллеру осуществляется через https://localhost:7210/api/notes/
    public class NotesController : ControllerBase
    {
        private readonly INotesStorage _storage;

        public NotesController(INotesStorage storage)
        {
            _storage = storage;
        }

        [HttpPost("Create")] //https://localhost:7210/api/notes/Create
        public async Task<string> Create(Note note)
        {
            _storage.AddNoteAsync(note);
            return $"Note created with description: {note.Description}";
        }
        [HttpGet("GetById")] //https://localhost:7210/api/notes/GetById?id=123
        public async Task<List<Note>> GetById(Guid id)
        {
            return await _storage.GetNotesByUserIdAsync(id);
        }

        [HttpPut("Update")] //https://localhost:7210/api/notes/Update
        public async Task<string> Update(Guid id, Note updatedNote)
        {
            _storage.UpdateNoteAsync(id, updatedNote);
            return $"Note with id {id} updated successfully";
        }

        [HttpDelete("Delete")] //https://localhost:7210/api/notes/Delete
        public async Task<string> Delete(Guid id)
        {
            _storage.DeleteNoteAsync(id);
            return $"Note with id {id} deleted successfully";
        }
    }
}
