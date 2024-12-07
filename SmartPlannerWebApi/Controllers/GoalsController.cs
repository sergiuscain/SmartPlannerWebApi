using Microsoft.AspNetCore.Mvc;

namespace SmartPlannerWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]   //Доступ к контроллеру осуществляется через https://localhost:7210/api/goals/
    public class GoalsController : ControllerBase
    {
        [HttpGet("GetHello")] // https://localhost:7210/api/goals/gethello
        public async Task<string> GetHello()
        {
            return "Hello Goals";
        }
    }
}
