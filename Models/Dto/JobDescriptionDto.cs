public class JobDescriptionDto
{
     public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int JobId { get; set; } // Foreign key
       
}