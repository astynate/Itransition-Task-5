namespace Itransition_Task_5.Models.Entities
{
    public class PersonModel
    {
        public uint Index { get; set; } = 0;
        public Guid Id { get; init; } = Guid.NewGuid();
        public string FullName { get; init; } = string.Empty;
        public string Address { get; private init; } = string.Empty;
        public string PhoneNumber { get; private init; } = string.Empty;
    }
}