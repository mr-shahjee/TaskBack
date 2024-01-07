// // AuthService.cs
// using Microsoft.EntityFrameworkCore;
// using PracticeCrud.Models;
// namespace PracticeCrud.Services
// {
// public class AuthService
// {
//     // Existing code...
//   private readonly UserContext _userContext;
//     public AuthService(UserContext userContext)
//     {
//         _userContext = userContext;
//     }
//     public void PostJobForm(JobDto jobDto)
//     {
//         // Map JobDto to your entity model and save it to the database
//         var jobEntity = new Job
//         {
//             JobTitle = jobDto.JobTitle,
//             Expiry = jobDto.Expiry,
//             JobDuration = jobDto.JobDuration,
//             JobDescription = jobDto.JobDescriptions.Select(descriptionDto => new JobDescription
//             {
//                 Name = descriptionDto.Name,
//                 Email = descriptionDto.Email
//             }).ToList()
//         };

//         // Save jobEntity to the database
//         // ...

//         // Return any necessary response
//     }

//     // Existing code...
//  public IEnumerable<JobDto> GetJobForm()
//     {
//         // Retrieve jobs from the database and map them to JobDto
//         var jobs = _userContext.Job.Include(j => j.JobDescription).ToList();

//         var jobDtos = jobs.Select(job => new JobDto
//         {
//             JobTitle = job.JobTitle,
//             Expiry = job.Expiry,
//             JobDuration = job.JobDuration,
//             JobDescriptions = job.JobDescription.Select(description => new JobDescriptionDto
//             {
//                 Name = description.Name,
//                 Email = description.Email
//             }).ToList()
//         });

//         return jobDtos;
//     }

//     // Existing code...
// }
// }
