using MediatR;
using StudentApi.Models.Students;
using StudentApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentApi.Mediatr.Students
{
    public class DeleteStudentCommand : IRequest<DeleteStudentResponse>
    {
        public Student Student { get; set; }
    }

    public class DeleteStudentResponse
    {
        public bool Result { get; set; }
    }

    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, DeleteStudentResponse>
    {
        private readonly IStudentsService _studentsService;

        public DeleteStudentHandler(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        public Task<DeleteStudentResponse> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var response = _studentsService.DeleteStudent(request.Student);

            return Task.FromResult(new DeleteStudentResponse()
            {
                Result = response
            });
        }

    }

}
