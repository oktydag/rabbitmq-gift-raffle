using System;
namespace GiftRaffle.Contracts
{
    public interface IApprovedEmployeeEvent
    {
        public Guid Id { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeEmail { get; set; }

        public string EmployeePhoneNumber { get; set; }
    }
}
