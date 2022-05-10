using StudentApi.Models.Students;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using StudentApi.Services;
using System.Linq;

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
        protected readonly IStudentsService _studentsService;

        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger, IStudentsService studentsService)
        {
            _logger = logger;
            _studentsService = studentsService;
        }

        /// <summary>
        /// Gets the current students
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await Task.Run(() => _studentsService.GetAllStudents());
            return Ok(result);
        }

        /// <summary>
        /// Add new student
        /// </summary>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<IActionResult> AddStudent(Student student)
        {
            student.StudentId = _studentsService.GetAllStudents().Max(x => x.StudentId) + 1;

            var result = await Task.Run(() => _studentsService.AddStudent(student));
            if (result)
            {
                return Ok();
            }
            return BadRequest("Error adding student!");
        }

        /// <summary>
        /// Edit student details
        /// </summary>
        /// <returns></returns>
        [HttpPost("details")]
        public async Task<IActionResult> DetailsStudent(Student student)
        {
            var result = await Task.Run(() => _studentsService.GetAllStudents().Find(s => s.StudentId == student.StudentId));
            if (result == null)
            {
                return NotFound("Student not found!");
            }
            return Ok(result);
        }

        /// <summary>
        /// Edit student details
        /// </summary>
        /// <returns></returns>
        [HttpPost("edit")]
        public async Task<IActionResult> EditStudent(Student student)
        {
            var result = await Task.Run(() => _studentsService.GetAllStudents().Find(s => s.StudentId == student.StudentId));
            if (result == null)
            {
                return NotFound("Student not found!");
            }

            result.FirstName = student.FirstName;
            result.LastName = student.LastName;
            result.Email = student.Email;
            result.Major = student.Major;
            result.Average = student.Average;

            return Ok();
        }

        /// <summary>
        /// Delete student
        /// </summary>
        /// <returns></returns>
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteStudent(Student student)
        {
            var result = await Task.Run(() => _studentsService.GetAllStudents().Find(s => s.StudentId == student.StudentId));
            if (result == null)
            {
                return NotFound("Student not found!");
            }
            _studentsService.DeleteStudent(result);
            return Ok(result);
        }
    }
}
