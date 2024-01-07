using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PracticeCrud.Models;

namespace PracticeCrud.Controllers
{
    [Route("Job")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class JobController : Controller
    {
        private readonly IConfiguration _config;
        public readonly UserContext _userContext;
        public JobController(IConfiguration config, UserContext userContext)
        {
            _config = config;
            _userContext = userContext;
        }


        [HttpPost]
        public IActionResult CreateJobData([FromBody] Job job)
        {
            _userContext.Job.Add(job);
            _userContext.SaveChanges();
            return Ok("Success from create method");
        }

        [HttpGet]
        public IActionResult GetJobData()
        { 
        var getData = _userContext.Job.ToList(); 
        return Ok(getData);
        }
  
    }
}