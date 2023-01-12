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
        /// Adds a new student
        /// </summary>
        /// <returns>true or false</returns>
        [HttpPost("Add")]
        public async Task<bool> Add([FromBody] Student student)
        {
            AddStudentRequest studentRequest = new AddStudentRequest
            {
                Student = student
            };
            var response = await Mediator.Send(studentRequest);

            return response;
        }
    }
}
