using Itransition_Task_5.Models.Accents;

namespace Itransition_Task_5.Models.Locales
{
    public class EnglishLocale : LocaleBase
    {
        public EnglishLocale(Random random) : base(random) { }

        public override char GetRandomLetter() 
            => _random.Next(0, 2) == 0 ? (char)_random.Next(65, 91)  : (char)_random.Next(97, 123);
    }
}