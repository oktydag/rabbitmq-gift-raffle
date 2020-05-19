using System;
namespace GiftRaffle.Contracts
{
    public interface IEmployee
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
