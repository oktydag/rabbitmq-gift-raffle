using System;
namespace GiftRaffle.App.RaffleServices.Contracts
{
    public interface IFakeDataService
    {
        string GetFakeFullName();
        
        string GetPhoneNumber();

        string GetEmailAddressByEmployeeName(string employeeName);
    }
}
