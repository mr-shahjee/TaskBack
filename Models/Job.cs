using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeCrud.Models
{
    [Table("Jobs")]
    public class Job
    {
        [Key]
         public int Id { get; set; }
        public string JobTitle { get; set; }
        public DateTime Expiry { get; set; }
        public int JobDuration { get; set; }
        public List<JobDescription> JobDescription { get; set; }
        
    }
}