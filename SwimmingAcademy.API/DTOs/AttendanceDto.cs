namespace SwimmingAcademy.API.DTOs
{
    public class AttendanceDto
    {
        public int AttendanceId { get; set; }
        public int SwimmerId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
    }
}
