using Itransition_Task_5.Models.Accents;
using Itransition_Task_5.Models.Locales;
using System.Text;

namespace Itransition_Task_5.Models.Errors
{
    public class AddSymbolError : ErrorBase
    {
        private readonly Dictionary<string, LocaleBase> _locales;

        public AddSymbolError(Random random) : base(random)
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
            if (value.Length >= _maxSize) return value;

            StringBuilder stringBuilder = new StringBuilder(value);

            stringBuilder.Insert(
                _random.Next(0, stringBuilder.Length + 1),
                _locales[_locale].GetRandomLetter()
            );

            return stringBuilder.ToString();
        }
    }
}