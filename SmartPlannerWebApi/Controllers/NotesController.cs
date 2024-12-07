using Microsoft.AspNetCore.Mvc;

namespace SmartPlannerWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]   //Доступ к контроллеру осуществляется через https://localhost:7210/api/notes/
    public class NotesController : ControllerBase
    {
        [HttpGet("test")]  //https://localhost:7210/api/notes/test
        public string TestNotes()
        {
            return "Test Notes";
        }
        [HttpGet("test2")]  //https://localhost:7210/api/notes/test2
        public string TestNotes2()
        {
            return "Nice Test^^";
        }
        [HttpGet("Hello")] //https://localhost:7210/api/notes/hello
        public async Task<string> Hello(string x)
        {
            return $"Hello {x}";
        }
    }
}
