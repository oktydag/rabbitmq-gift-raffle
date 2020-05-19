using GiftRaffle.Contracts;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace GiftRaffle.EmailNotificationService
{
    public class GiftRaffleApprovedEventConsumer : IConsumer<IApprovedEmployeeEvent>
    {
        public async Task Consume(ConsumeContext<IApprovedEmployeeEvent> context)
        {
            // DO Email Operation.
            await Console.Out.WriteLineAsync($"Email sent for this employee --> Name: {context.Message.EmployeeName} - Email: {context.Message.EmployeeEmail} - Operation Id: {context.Message.Id}" );
        }
    }
}
