using System;
using GiftRaffle.Contracts;
using GreenPipes;
using MassTransit;

namespace GiftRaffle.SMSNotificationService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "SMS Notification";

            var bus = BusConfigurator.ConfigureBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(RabbitMQConstants.RabbitMqSmsNotificationQueueName, e =>
                {
                    e.Consumer<GiftRaffleApprovedEventConsumer>();
                    //e.UseRateLimit(10000, TimeSpan.FromMinutes(1));
                });
            });
            bus.StartAsync();
            Console.WriteLine("Listening SMS Notification ");
            Console.ReadLine();
            bus.StopAsync();

        }
    }
}
