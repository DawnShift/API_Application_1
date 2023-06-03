using API_Application_1.Interfaces;
using API_Application_1.Model;
using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Mvc;

namespace API_Application_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {

        private readonly ILogger<MessageController> _logger;
        private readonly IMessageRepository repo;
        private readonly IConfiguration config;

        public MessageController(ILogger<MessageController> logger, IMessageRepository _repo, IConfiguration _config)
        {
            _logger = logger;
            repo = _repo;
            config = _config;
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

        [HttpPost]
        [Route("api/InitiateMessage")]
        public async Task<IActionResult> InitiateMessage(string message)
        {
            if(message != null)
            {
                string connectionString = config["ServiceBus"];
                string queueName = "firstqueue";
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using var client = new ServiceBusClient(connectionString);

                // create the sender
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send. UTF-8 encoding is used when providing a string.
                ServiceBusMessage msg = new ServiceBusMessage(message);
                await sender.SendMessageAsync(msg);
            }
            return Ok();
        }
    }
}