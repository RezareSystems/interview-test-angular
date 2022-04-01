using interview_test_angular.Mediatr.Students;
using interview_test_angular.Models.Students;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interview_test_angular.Controllers
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

        [HttpPost("Add")]
        public async Task<bool> AddStudent([FromBody] StudentAPI student)
        {
            AddStudentRequest studentRequest = new AddStudentRequest
            {
                Student = student.student
            };
            var result = await Mediator.Send(studentRequest);
            return result;
        }

        [HttpPost("Delete")]
        public async Task<bool> DeleteStudent([FromBody] StudentAPI student)
        {
            DeleteStudentRequest deleteStudentRequest = new DeleteStudentRequest
            {
                Student = student.student
            };
            var result = await Mediator.Send(deleteStudentRequest);
            return result;
        }
    }
}