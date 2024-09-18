using Itransition_Task_5.Models.Entities;

namespace Itransition_Task_5.Models.Errors
{
    public abstract class ErrorBase : RandomBase
    {
        protected readonly int _minSize = 5;

        protected readonly int _maxSize = 40;

        protected readonly string _locale = "en";

        public ErrorBase(Random random) : base(random) { }

        public abstract string AddError(string value);
    }
}