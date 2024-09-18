namespace Itransition_Task_5.Models
{
    public record PersonModel
    (
        Guid Id,
        string FullName,
        string Address,
        string PhoneNumber
    )
    {
        public PersonModel() : this(Guid.NewGuid(), string.Empty, string.Empty, string.Empty) { }
    }
}