using Itransition_Task_5.Models.Entities;

namespace Itransition_Task_5.Models.Accents
{
    abstract public class LocaleBase : RandomBase
    {
        public LocaleBase(Random random) : base(random) { }

        public abstract char GetRandomLetter();
    }
}