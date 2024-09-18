using Bogus;
using Itransition_Task_5.Models.Entities;
using Itransition_Task_5.Models.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Itransition_Task_5.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(double error = 100, int seed = 128, string localization = "en")
        {
            error = Math.Min(error, 1000);
            seed = Math.Min(seed, 100);

            ViewBag.Persons = GeneratePersonsData
            (
                20,
                error,
                seed, 
                new Faker<PersonModel>(localization)
            );

            return View();
        }

        private List<PersonModel> GeneratePersonsData(int count, double error, int seed, Faker<PersonModel> fakerInstance)
        {
            var random = new Random(seed);
            var persons = new List<PersonModel>();
            
            fakerInstance.UseSeed(seed);

            var errorGenerator = new ErrorGenerator(random);

            fakerInstance
                .RuleFor(u => u.Id, (f, u) => Guid.NewGuid())
                .RuleFor(u => u.FullName, (f, u) => errorGenerator.GenerateMistake(error, $"{f.Name.FirstName()} {f.Name.LastName()}"))
                .RuleFor(u => u.Address, (f, u) => errorGenerator.GenerateMistake(error, $"{f.Address.City()}, {f.Address.StreetName()}"))
                .RuleFor(u => u.PhoneNumber, (f, u) => errorGenerator.GenerateMistake(error, $"{f.Phone.PhoneNumber()}"));

            for (int i = 0; i < count; i++)
            {
                persons.Add(fakerInstance.Generate());
            }

            return persons;
        }
    }
}