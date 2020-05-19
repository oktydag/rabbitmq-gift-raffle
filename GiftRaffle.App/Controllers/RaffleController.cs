using System;
using System.Text;
using System.Threading.Tasks;
using GiftRaffle.App.RaffleServices.Contracts;
using GiftRaffle.Contracts;
using Microsoft.AspNetCore.Mvc;


namespace GiftRaffle.App.Controllers
{
    [Route("api/[controller]")]
    public class RaffleController : Controller
    {
        private readonly IFakeDataService _fakeDataService;

        public RaffleController(IFakeDataService fakeDataService)
        {
            _fakeDataService = fakeDataService;
        }



        // GET: api/giftraffle
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            // Due to fake data library, I assume that random generated Phone Numbers and Email Addresses belong that Employee.

            StringBuilder responseMessageBuilder = new StringBuilder();

            responseMessageBuilder.AppendLine("Gift Raffle is starting ! ");
            responseMessageBuilder.AppendLine("Here is lucky employees; ");

            var bus = BusConfigurator.ConfigureBus();

            var sendToUri = new Uri($"{RabbitMQConstants.RabbitMqUri}{RabbitMQConstants.RabbitMqGiftRaffleQueueName}");
            var endPoint = await bus.GetSendEndpoint(sendToUri);

            const int LUCKY_EMPLOYEE_COUNT = 10000; //10k

            for (int i = 0; i < LUCKY_EMPLOYEE_COUNT; i++)
            {

                var luckyEmployee = _fakeDataService.GetFakeFullName();

                await endPoint.Send<IEmployee>(new
                {
                    Name = luckyEmployee,
                    PhoneNumber = _fakeDataService.GetPhoneNumber(),
                    Email = _fakeDataService.GetEmailAddressByEmployeeName(luckyEmployee)
                });

                responseMessageBuilder.AppendLine($"{i+1}- {luckyEmployee}");

            }

            responseMessageBuilder.AppendLine("*************");
            responseMessageBuilder.AppendLine("Email and SMS sent for them !");

            return Ok(responseMessageBuilder.ToString());
        }
    }
}
