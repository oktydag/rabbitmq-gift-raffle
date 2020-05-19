using System;
using GiftRaffle.Contracts;
using GreenPipes;
using MassTransit;

namespace GiftRaffle.Approver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Approver";

            var bus = BusConfigurator.ConfigureBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(
                    RabbitMQConstants.RabbitMqGiftRaffleQueueName, e =>
                    {
                        e.Consumer<ApproverFinderConsumer>();
                        e.UseCircuitBreaker(cb =>
                        {
                            cb.TrackingPeriod = TimeSpan.FromMinutes(1);
                            cb.TripThreshold = 15;
                            cb.ActiveThreshold = 10;
                            cb.ResetInterval = TimeSpan.FromMinutes(5);
                        });

                    });
                
            });

            bus.StartAsync();
            
            Console.WriteLine("Listening for Approvals ");
            Console.ReadLine();

            bus.StopAsync();

        }
    }
}
