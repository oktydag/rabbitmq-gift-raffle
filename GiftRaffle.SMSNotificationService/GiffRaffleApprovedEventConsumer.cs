using GiftRaffle.Contracts;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace GiftRaffle.SMSNotificationService
{
    public class GiftRaffleApprovedEventConsumer : IConsumer<IApprovedEmployeeEvent>
    {
        public async Task Consume(ConsumeContext<IApprovedEmployeeEvent> context)
        {
            await Console.Out.WriteLineAsync($"SMS sent: id {context.Message.Id} and Name : {context.Message.EmployeeName}  " );
        }
    }
}
