using MediatR;
using StudentApi.Models.Students;
using StudentApi.Services;
using System.Threading;
using System.Threading.Tasks;

namespace StudentApi.Mediatr.Students
{
    public class AddStudentRequest : IRequest<bool>
    {
        public Student Student { get; set; }
    }

    public class AddStudentHandler : IRequestHandler<AddStudentRequest, bool>
    {
        private IStudentsService _studentsService;

        public AddStudentHandler(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        public Task<bool> Handle(AddStudentRequest request, CancellationToken cancellationToken)
        {
            var response = _studentsService.AddStudent(request.Student);

            return Task.FromResult(response);
        }
    }
}
