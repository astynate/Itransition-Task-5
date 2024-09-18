namespace Itransition_Task_5.Models.Accents
{
    public class FrenchLocale : LocaleBase
    {
        public FrenchLocale(Random random) : base(random) { }

        public override char GetRandomLetter() 
            => _random.Next(0, 2) == 0 ? (char)_random.Next(97, 123) : GetRandomFrenchAccent(_random);

        static char GetRandomFrenchAccent(Random random)
        {
            char[] frenchAccents = { 'à', 'â', 'ç', 'é', 'è', 'ê', 'ë', 'î', 'ï', 'ô', 'û', 'ù', 'ü' };
            return frenchAccents[random.Next(frenchAccents.Length)];
        }
    }
}