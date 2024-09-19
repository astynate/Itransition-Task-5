using Bogus;
using Itransition_Task_5.Models.Entities;
using Itransition_Task_5.Models.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Itransition_Task_5.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Users(int count = 20, int page = 0, double error = 100, int seed = 128, string localization = "en")
        {
            error = Math.Max(0, Math.Min(error, 1000));
            seed = Math.Max(0, Math.Min(seed, 1000));

            ViewBag.Persons = GeneratePersonsData
            (
                count,
                page,
                error,
                seed + count + page,
                new Faker<PersonModel>(localization)
            );

            return PartialView();
        }

        public IActionResult Index()
        {
            return View();
        }

        private List<PersonModel> GeneratePersonsData(int count, int page, double error, int seed, Faker<PersonModel> fakerInstance)
        {
            var random = new Random(seed);
            var persons = new List<PersonModel>();
            
            fakerInstance.UseSeed(seed);
            error = RoundWithProbability(error, random);

            var errorGenerator = new ErrorGenerator(random);
            var prevCountUsers = page >= 2 ? (page - 1) * 10 + 20 : page == 1 ? 20 : 0;

            fakerInstance
                .RuleFor(u => u.Index, (f, u) => prevCountUsers + persons.Count + 1)
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

        static double RoundWithProbability(double num, Random random)
        {
            if (num % 1 == 0) { return num; }

            double fractionalPart = num - Math.Floor(num);
            double threshold = random.NextDouble();

            return threshold < fractionalPart ? Math.Ceiling(num) : Math.Floor(num);
        }
    }
}