using interview_test_angular.Models.Students;
using interview_test_angular.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace interview_test_angular.Mediatr.Students
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
            // Add Student
            var response = _studentsService.AddStudent(request.Student);
            return Task.FromResult(response);
        }
    }
}
