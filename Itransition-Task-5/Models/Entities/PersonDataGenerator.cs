using Bogus;
using Itransition_Task_5.Models.Errors;

namespace Itransition_Task_5.Models.Entities
{
    public static class PersonDataGenerator
    {
        public static List<PersonModel> GeneratePersonsData(int count, int page, double error, int seed, Faker<PersonModel> fakerInstance)
        {
            var random = new Random(seed);
            var persons = new List<PersonModel>();

            fakerInstance.UseSeed(seed);
            error = RoundWithProbability(error, random);

            var errorGenerator = new ErrorGenerator(random);
            var prevCountUsers = page >= 2 ? (page - 1) * 10 + 20 : page == 1 ? 20 : 0;

            fakerInstance
                .RuleFor(u => u.Id, (f, u) => Guid.NewGuid())
                .RuleFor(u => u.FullName, (f, u) => errorGenerator.GenerateMistake(error, $"{f.Name.FirstName()} {f.Name.LastName()}"))
                .RuleFor(u => u.Address, (f, u) => errorGenerator.GenerateMistake(error, $"{f.Address.City()}, {f.Address.StreetName()}"))
                .RuleFor(u => u.PhoneNumber, (f, u) => errorGenerator.GenerateMistake(error, $"{f.Phone.PhoneNumber()}"));

            for (int i = 0; i < count; i++)
            {
                persons.Add(fakerInstance.Generate());
                persons[i].Index = (uint)(prevCountUsers + i + 1);
            }

            return persons;
        }

        private static double RoundWithProbability(double num, Random random)
        {
            if (num % 1 == 0) { return num; }

            double fractionalPart = num - Math.Floor(num);
            double threshold = random.NextDouble();

            return threshold < fractionalPart ? Math.Ceiling(num) : Math.Floor(num);
        }
    }
}