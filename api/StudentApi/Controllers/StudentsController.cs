using StudentApi.Mediatr.Students;
using StudentApi.Models.Students;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private IMediator mediator;

        /// <summary>
        /// Gets the Mediator object.
        /// </summary>
        protected IMediator Mediator => mediator ??= (IMediator)HttpContext.RequestServices.GetService(typeof(IMediator))!;

        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets the current students
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Student>> Get()
        {
            var reponse = await Mediator.Send(new GetStudentsRequest());

            return reponse.Students;
        }

        /// <summary>
        /// Add new student
        /// </summary>
        /// <returns>boolean</returns>
        [HttpPost]
        public async Task<bool> AddStudents(Student student)
        {
            try
            {
                var reponse = await Mediator.Send(new AddStudentCommand() { Student = student });

                return reponse.Result;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
            
        }

        /// <summary>
        /// Delete existing student
        /// </summary>
        /// <returns>boolean</returns>
        [HttpPost]
        public async Task<bool> DeleteStudents(Student student)
        {
            try
            {
                var reponse = await Mediator.Send(new DeleteStudentCommand() { Student = student });

                return reponse.Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
