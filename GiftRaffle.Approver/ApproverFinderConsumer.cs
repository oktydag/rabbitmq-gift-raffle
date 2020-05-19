using System;
using System.Threading.Tasks;
using GiftRaffle.Contracts;
using MassTransit;

namespace GiftRaffle.Approver
{
    public class ApproverFinderConsumer : IConsumer<IEmployee>
    {
        public Task Consume(ConsumeContext<IEmployee> context)
        {
            var message = context.Message;
            var guid = Guid.NewGuid();

            Console.WriteLine($" Giff Raffle operation is success. Id:{guid}");

            context.Publish<IApprovedEmployeeEvent>(new
            {
                Id = guid,
                EmployeeName = message.Name,
                EmployeeEmail = message.Email,
                EmployeePhoneNumber = message.PhoneNumber
            });

            return Task.CompletedTask;
        }
    }
}
