namespace SwimmingAcademy.API.DTOs
{
    public class LoginDto
    {
        public int UserId { get; set; } 
        public string Password { get; set; } = string.Empty;
    }
}
