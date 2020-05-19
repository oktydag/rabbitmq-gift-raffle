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
                    e.UseMessageRetry(r => r.Immediate(2)); // if you want to retry
                    e.UseRateLimit(10000, TimeSpan.FromMinutes(1)); // if you want to limit 
                });
            });

            bus.StartAsync();
            Console.WriteLine("Listening Email Notification ");
            Console.ReadLine();
            bus.StopAsync();

        }
    }
}
