using System;

namespace GiftRaffle.Contracts
{
    public class RabbitMQConstants
    {
        public static string RabbitMqUri => "rabbitmq://localhost/";
        public static string RabbitMqUserName => "oktydag"; //default : guest
        public static string RabbitMqPassword => "123456"; // default : guest 

        public static string RabbitMqGiftRaffleQueueName => "gift.raffle.approver.service";
        public static string RabbitMqEmailNotificationQueueName => "email.notification.service";
        public static string RabbitMqSmsNotificationQueueName => "sms.notification.service";
    }

}
