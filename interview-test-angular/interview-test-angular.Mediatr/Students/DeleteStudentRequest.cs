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
    public class DeleteStudentRequest : IRequest<bool>
    {
        public Student Student { get; set; }
    }

    public class DeleteStudentHandler : IRequestHandler<DeleteStudentRequest, bool>
    {
        private IStudentsService _studentsService;

        public DeleteStudentHandler(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        public Task<bool> Handle(DeleteStudentRequest request, CancellationToken cancellationToken)
        {
            // Delete Student
            var response = _studentsService.DeleteStudent(request.Student);
            return Task.FromResult(response);
        }
    }
}
