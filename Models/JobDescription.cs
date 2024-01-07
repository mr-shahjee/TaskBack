using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeCrud.Models
{
    [Table("JobDescription")] 
    public class JobDescription
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int JobId { get; set; } // Foreign key
         [ForeignKey("JobId")]
        public Job Job { get; set; } // Navigation property
    }
}