using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PracticeCrud.Models; 
using AutoMapper;

namespace PracticeCrud.Controllers
{
    [Route("Job")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class JobController : Controller
    {
        private readonly IConfiguration _config;
        public readonly UserContext _userContext;
         public readonly IMapper _mapper;
        public JobController(IConfiguration config, UserContext userContext, IMapper mapper)
        {
            _config = config;
            _userContext = userContext;
            _mapper=mapper;
        }

private Job MapJobObject(JobDto jobDto){
    var result = new Job();
    result.JobTitle = jobDto.JobTitle;
    result.Expiry = jobDto.Expiry;
    result.JobDuration = jobDto.JobDuration;
    result.JobDescription = new List<JobDescription>();
    jobDto.JobDescription.ForEach(_ => {
        var descriptions = new JobDescription();
        descriptions.Name = _.Name;
        descriptions.Email = _.Email;
        result.JobDescription.Add(descriptions);
    });
   return result;
}
        [HttpPost]
        public async Task<IActionResult> CreateJobData(JobDto job)
        {
           var newJob = MapJobObject(job);
            _userContext.Job.Add(newJob);
            await _userContext.SaveChangesAsync();
            return Created("", newJob);
        }

        [HttpGet]
        public IActionResult GetJobData()
        { 
        var getData = _userContext.Job.ToList(); 
        return Ok(getData);
        }
  
    }
}