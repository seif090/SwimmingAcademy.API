public class SwimmerInfoTabDto
{
    // Swimmer (Info2) fields
    public string FullName { get; set; }
    public DateOnly BirthDate { get; set; }
    public string CurrentLevel { get; set; }
    public string StartLevel { get; set; }
    public DateTime CreatedAtDate { get; set; }
    public string Club { get; set; }

    // Parent fields
    public string PrimaryJob { get; set; }
    public string SecondaryJob { get; set; }
    public string PrimaryPhone { get; set; }
    public string SecondaryPhone { get; set; }
}