using Bogus;
using PaginationV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaginationV.FakerData
{
    public static class FakeUser
    {
        public static List<User> users;

        public static List<User> AllUser(int number)
        {
            if (users == null)
            {
                users = new Faker<User>()
                 .RuleFor(x => x.ID, i => i.IndexFaker + 1)
                    .RuleFor(x => x.Name, n => n.Name.FirstName())
                    .RuleFor(x => x.LastName, l => l.Name.LastName())
                    .RuleFor(x=>x.City , n=>n.Address.Country())
                    .RuleFor(x=>x.Email , n=>n.Internet.Email())
                    .RuleFor(p => p.Phone, f => f.Phone.PhoneNumberFormat())
                    .RuleFor(p => p.DateOfBirth, f => f.Date.Past(25))
                    .RuleFor(x=> x.CityCode, f=> f.Address.CountryCode())
                    .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
                    .RuleFor(x=> x.Image, f=>f.Internet.Avatar())
                    .Generate(number);
            }

            return users;

        }

    }
}
