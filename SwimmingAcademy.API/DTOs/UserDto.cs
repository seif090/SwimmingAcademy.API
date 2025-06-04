namespace SwimmingAcademy.API.DTOs
{
    public class UserDto
    {
        public int Userid { get; set; }
        public string Fullname { get; set; }
        public string Site { get; set; }
        public bool Disabled { get; set; }
        public int UserTypeId { get; set; }
    }
}
