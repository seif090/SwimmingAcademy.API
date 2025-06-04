namespace SwimmingAcademy.API.DTOs
{
    public class SwimmerDto
    {
        public int SwimmerId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = string.Empty;
        public int Site { get; set; }
    }
}
