using Bogus;
using CsvHelper;
using Itransition_Task_5.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;
using static Itransition_Task_5.Controllers.HomeController;

namespace Itransition_Task_5.Controllers
{
    public class ExportController : Controller
    {
        [HttpGet]
        public IActionResult Index([FromQuery] UserRequest request)
        {
            List<PersonModel> users = new List<PersonModel>();

            for (int i = 0; i < request.Page + 1; i++)
            {
                int count = i == 0 ? 20 : 10;

                users.AddRange(
                    PersonDataGenerator.GeneratePersonsData
                    (
                        count,
                        i,
                        request.Error,
                        request.Seed + i + count,
                        new Faker<PersonModel>(request.Localization)
                    )
                );
            }

            using (var memoryStream = new MemoryStream())
            using (var writer = new StreamWriter(memoryStream, new UTF8Encoding(false)))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(users);
                writer.Flush();
                memoryStream.Position = 0;

                return File(memoryStream.ToArray(), "text/csv", "users.csv");
            }
        }
    }
}