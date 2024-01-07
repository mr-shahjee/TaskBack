public class JobDto
{
    public string JobTitle { get; set; }
    public DateTime Expiry { get; set; }
    public int JobDuration { get; set; }
    public List<JobDescriptionDto> JobDescriptions { get; set; }
}