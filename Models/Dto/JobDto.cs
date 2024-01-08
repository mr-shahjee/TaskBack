public class JobDto
{
     public int Id { get; set; }
        public string JobTitle { get; set; }
        public DateTime Expiry { get; set; }
        public int JobDuration { get; set; }
        public List<JobDescriptionDto> JobDescription { get; set; }
}