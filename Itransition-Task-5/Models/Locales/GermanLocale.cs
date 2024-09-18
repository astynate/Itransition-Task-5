namespace Itransition_Task_5.Models.Accents
{
    public class GermanLocale : LocaleBase
    {
        public GermanLocale(Random random) : base(random) { }

        public override char GetRandomLetter() 
            => _random.Next(0, 2) == 0 ? (char)_random.Next(97, 123) : GetRandomGermanSpecial(_random);

        static char GetRandomGermanSpecial(Random random)
        {
            char[] germanSpecials = { 'ä', 'ö', 'ü', 'ß' };
            return germanSpecials[random.Next(germanSpecials.Length)];
        }
    }
}