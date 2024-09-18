using Itransition_Task_5.Models.Accents;
using Itransition_Task_5.Models.Locales;
using System.Text;

namespace Itransition_Task_5.Models.Errors
{
    public class SwapSymbolError : ErrorBase
    {
        private readonly Dictionary<string, LocaleBase> _locales;

        public SwapSymbolError(Random random) : base(random) 
        {
            _locales = new Dictionary<string, LocaleBase>()
            {
                { "en", new EnglishLocale(_random) },
                { "fr", new FrenchLocale(_random) },
                { "de", new GermanLocale(_random) },
            };
        }

        public override string AddError(string value)
        {
            StringBuilder stringBuilder = new StringBuilder(value);

            var firstIndex = stringBuilder.ToString();
            var secondIndex = _random.Next();

            return stringBuilder.ToString();
        }
    }
}