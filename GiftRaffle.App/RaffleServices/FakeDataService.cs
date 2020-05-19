using GiftRaffle.App.RaffleServices.Contracts;

namespace GiftRaffle.App.RaffleServices
{
    public class FakeDataService : IFakeDataService
    {

        public string GetFakeFullName()
        {
            return Faker.NameFaker.Name().ToLower();
        }

        public string GetPhoneNumber()
        {
            return Faker.PhoneFaker.Phone();
        }

        public string GetEmailAddressByEmployeeName(string employeeName)
        {
            return $"{employeeName.Replace(" ", ".")}@campany.com";
        }
    }
}
