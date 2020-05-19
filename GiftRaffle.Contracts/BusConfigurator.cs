using System;
using MassTransit;
using MassTransit.RabbitMqTransport;

namespace GiftRaffle.Contracts
{
    public static class BusConfigurator
    {
        public static IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> giftRaffleAction = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(RabbitMQConstants.RabbitMqUri), hst =>
                {
                    hst.Username(RabbitMQConstants.RabbitMqUserName);
                    hst.Password(RabbitMQConstants.RabbitMqPassword);
                });

                giftRaffleAction?.Invoke(cfg, host);
            });

        }
    }
}
