namespace SwimmingAcademy.API.DTOs
{
    public class LevelDto
    {
        public short MainId { get; set; }
        public short SubId { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool Disabled { get; set; }
    }
}
