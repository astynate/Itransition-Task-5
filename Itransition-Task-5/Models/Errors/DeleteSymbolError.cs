using System.Text;

namespace Itransition_Task_5.Models.Errors
{
    public class DeleteSymbolError : ErrorBase
    {
        public DeleteSymbolError(Random random) : base(random) { }

        public override string AddError(string value)
        {
            if (value.Length <= _minSize) return value;

            StringBuilder result = new StringBuilder();

            var charArray = value.ToCharArray();
            var indexToRemove = _random.Next(charArray.Length);

            for (int i = 0; i < charArray.Length; i++)
            {
                if (i != indexToRemove)
                {
                    result.Append(charArray[i]);
                }
            }

            return result.ToString();
        }
    }
}