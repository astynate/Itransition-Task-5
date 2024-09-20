using Bogus;
using Itransition_Task_5.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Itransition_Task_5.Controllers
{
    public class HomeController : Controller
    {
        public record UserRequest
        {
            public int Count { get; set; } = 20;
            public int Page { get; set; } = 0;

            private double _error = 0;
            public double Error
            {
                get => _error;
                set => _error = Math.Max(0, Math.Min(value, 1000));
            }

            private int _seed = 128;
            public int Seed
            {
                get => _seed;
                set => _seed = Math.Max(0, Math.Min(value, 1000));
            }

            public string Localization { get; set; } = "en";
        }

        [HttpGet]
        public IActionResult Users([FromQuery] UserRequest request)
        {
            ViewBag.Persons = PersonDataGenerator.GeneratePersonsData
            (
                request.Count,
                request.Page,
                request.Error,
                request.Seed + request.Count + request.Page,
                new Faker<PersonModel>(request.Localization)
            );

            return PartialView();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}