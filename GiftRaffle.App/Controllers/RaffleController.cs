using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiftRaffle.Contracts;
using Microsoft.AspNetCore.Mvc;


namespace GiftRaffle.App.Controllers
{
    [Route("api/[controller]")]
    public class RaffleController : Controller
    {
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bus = BusConfigurator.ConfigureBus();

            var sendToUri = new Uri($"{RabbitMQConstants.RabbitMqUri}{RabbitMQConstants.RabbitMqGiftRaffleQueueName}");
            var endPoint = await bus.GetSendEndpoint(sendToUri);

            await endPoint.Send<IEmployee>(new
            {
               Name = "Oktay"
            });

            return Ok("well done !");
        }
    }
}
