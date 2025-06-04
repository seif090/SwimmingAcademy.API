namespace SwimmingAcademy.API.DTOs
{
    public class SwimmerListDto
    {
        public string Fullname { get; set; }
        public DateOnly Birthdate { get; set; }
        public string CurrentLevel { get; set; }
        public string Site { get; set; }
        public string Club { get; set; }
    }
}
