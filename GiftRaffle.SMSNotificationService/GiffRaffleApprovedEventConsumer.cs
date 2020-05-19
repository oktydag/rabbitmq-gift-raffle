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
            // Do SMS operation.
            await Console.Out.WriteLineAsync($"SMS sent for this employee --> Name: {context.Message.EmployeeName} - SMS: {context.Message.EmployeePhoneNumber} - Operation Id: {context.Message.Id}");
        }
    }
}
