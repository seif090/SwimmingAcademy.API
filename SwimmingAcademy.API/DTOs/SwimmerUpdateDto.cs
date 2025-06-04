namespace SwimmingAcademy.API.DTOs
{
    public class SwimmerUpdateDto
    {
        public string FullName { get; set; }
        public DateOnly BirthDate { get; set; }
        public short StartLevel { get; set; }
        public short Gender { get; set; }
        public short Club { get; set; }
        public string PrimaryPhone { get; set; }
        public string? SecondaryPhone { get; set; }
        public string PrimaryJob { get; set; }
        public string? SecondaryJob { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
