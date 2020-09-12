using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;

namespace ServiceBusSendMessage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        const string QueueConnectionString = "Endpoint=sb://antonio16net.servicebus.windows.net/;SharedAccessKeyName=ProductPolicy;SharedAccessKey=vSdVUAHVEKqLBEm/GHV5GfrD4DbcmjTDNVB0yMG28Eg=";
        const string QueuePath = "productchanged";
        static IQueueClient _queueClient;

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            SendMessagesAsync().GetAwaiter().GetResult();
            return new string[] { "value1", "value2" };
        }

        private static async Task SendMessagesAsync()
        {
            _queueClient = new QueueClient(QueueConnectionString, QueuePath);
            var messages = "Hi,Hello,Hey,How are you,Be Welcome, Antonio"
                .Split(',')
                .Select(msg =>
                {
//                    Console.WriteLine($"Will send message: {msg}");
                    return new Message(Encoding.UTF8.GetBytes(msg));
                }).ToList();
            await _queueClient.SendAsync(messages);
            await _queueClient.CloseAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "Value";
        }

        // POST api/values
        [HttpPost("value")]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
