namespace Itransition_Task_5.Models.Entities
{
    public abstract class RandomBase
    {
        protected readonly Random _random;

        public RandomBase(Random random)
        {
            _random = random;
        }
    }
}