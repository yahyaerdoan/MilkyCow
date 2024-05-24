namespace MilkyCow.DataTransferObjectLayer.Concrete.TestimonialDtos
{
    public record UpdateTestimonialDto(int TestimonialId, string FirstName, string LastName, string ImageUrl, string Title, string Description, bool Status);
}
