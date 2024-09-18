using Bogus;
using Itransition_Task_5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Itransition_Task_5.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int seed = 128, string localization = "en")
        {
            ViewBag.Persons = GeneratePersonsData
            (
                20, 
                seed, 
                new Faker<PersonModel>(localization)
            );

            return View();
        }

        private List<PersonModel> GeneratePersonsData(int count, int seed, Faker<PersonModel> fakerInstance)
        {
            var random = new Random(seed);
            var persons = new List<PersonModel>();
            
            fakerInstance.UseSeed(seed);

            fakerInstance
                .RuleFor(u => u.Id, (f, u) => Guid.NewGuid())
                .RuleFor(u => u.FullName, (f, u) => $"{f.Name.FirstName()} {f.Name.LastName()}")
                .RuleFor(u => u.Address, (f, u) => $"{f.Address.City()}, {f.Address.StreetName()}")
                .RuleFor(u => u.PhoneNumber, (f, u) => $"{f.Phone.PhoneNumber()}");

            for (int i = 0; i < count; i++)
            {
                persons.Add(fakerInstance.Generate());
            }

            return persons;
        }
    }
}