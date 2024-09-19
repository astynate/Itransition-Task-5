namespace Itransition_Task_5.Models.Entities
{
    public record PersonModel
    (
        int Index,
        Guid Id,
        string FullName,
        string Address,
        string PhoneNumber
    )
    {
        public PersonModel() : this(0, Guid.NewGuid(), string.Empty, string.Empty, string.Empty) { }
    }
}