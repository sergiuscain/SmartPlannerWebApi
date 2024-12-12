using System;
using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpPost()] //https://localhost:7210/api/notes/Create
        public async Task<IActionResult> Create(Note note)
        {
                    note.UserId = TestData.UserId;  //Временное решение
            note.Id = Guid.NewGuid();
            note.CreatedDate = DateTime.Now;
            note.UpdatedDate = DateTime.Now;
            var res = await _storage.AddNoteAsync(note);
            if (res)
                return Created();
            return Conflict();
        }
        [HttpGet()] //https://localhost:7210/api/notes/?id=123
        public async  Task<ActionResult<List<Note>>> GetById(Guid id)
        {
                                 id = TestData.UserId; //временное решение!!
            var notes = await  _storage.GetNotesByUserIdAsync(id);
            if (notes == null)
                return NotFound("Такого пользователя не существует!");
            return Ok(notes);

        }

        [HttpPut()] //https://localhost:7210/api/notes
        public async Task<ActionResult<string>> Update(Guid id, Note updatedNote)
        {
            await _storage.UpdateNoteAsync(id, updatedNote);
            return  Ok();
        }

        [HttpDelete()] //https://localhost:7210/api/notes/Delete
        public async Task<ActionResult<string>> Delete(Guid id)
        {
            var res = await _storage.DeleteNoteAsync(id);
            if(res)
                return Ok();
            return Conflict("Заметка с таким Id не найдена");
        }
    }
}
