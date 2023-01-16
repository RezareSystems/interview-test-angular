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
    public class AddStudentCommand : IRequest<AddStudentResponse>
    {
        public Student Student { get; set; }
    }

    public class AddStudentResponse
    {
        public bool Result { get; set; }
    }

    public class AddStudentHandler : IRequestHandler<AddStudentCommand, AddStudentResponse>
    {
        private readonly IStudentsService _studentsService;

        public AddStudentHandler(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        public Task<AddStudentResponse> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var response = _studentsService.AddStudent(request.Student);

            return Task.FromResult(new AddStudentResponse()
            {
                Result = response
            });
        }
    }

}
