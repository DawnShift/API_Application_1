using API_Application_1.Interfaces;
using API_Application_1.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_Application_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {

        private readonly ILogger<MessageController> _logger;
        private readonly IMessageRepository repo;

        public MessageController(ILogger<MessageController> logger, IMessageRepository _repo)
        {
            _logger = logger;
            repo = _repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        { 
            return Ok(await repo.GetAll());
        }

        [HttpPost]
        public IActionResult CreateMessage([FromBody] Message message)
        {
            repo.Add(message);
            return Ok(message);
        }
    }
}