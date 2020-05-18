using GiftRaffle.Contracts;
using GreenPipes;
using MassTransit;
using System;

namespace GiftRaffle.EmailNotificationService
{
    class Program
    {
        static  void Main(string[] args)
        {
            Console.Title = "Email Notification";
            var bus = BusConfigurator.ConfigureBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(RabbitMQConstants.RabbitMqEmailNotificationQueueName, e =>
                {
                    e.Consumer<GiftRaffleApprovedEventConsumer>();
                    e.UseMessageRetry(r => r.Immediate(5));
                });
            });

            bus.StartAsync();
            Console.WriteLine("Listening Email Notification for approved events.. Press enter to exit");
            Console.ReadLine();
            bus.StopAsync();

        }
    }
}
