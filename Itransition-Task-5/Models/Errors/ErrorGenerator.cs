namespace Itransition_Task_5.Models.Errors
{
    public class ErrorGenerator
    {
        private readonly Random _random;

        public ErrorGenerator(Random random)
        {
            _random = random;
        }

        public string GenerateMistake(double error, string value)
        {
            ErrorBase[] handlers = [
                new AddSymbolError(_random), 
                new DeleteSymbolError(_random), 
                new SwapSymbolError(_random)
            ];

            for (int i = 0; i < error; ++i)
            {
                value = handlers[_random.Next(handlers.Length)].AddError(value);
            }

            return value;
        }
    }
}