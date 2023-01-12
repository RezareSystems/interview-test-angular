using StudentApi.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApi.Services
{
    public class StudentsService : IStudentsService
    {
        public List<Student> students = new List<Student>();

        public StudentsService()
        {
            students.Add(new Student
            {
                Id = 1,
                FirstName = "Marty",
                LastName = "McFly",
                Email = "back.future@test.com",
                Major = "History",
                AverageGrade = 25
            });

            students.Add(new Student {
                Id = 2,
                FirstName = "Emmett",
                LastName = "Brown",
                Email = "dr.brown@test.com",
                Major = "Physics",
                AverageGrade = 50
            });

            students.Add(new Student
            {
                Id = 3,
                FirstName = "Biff",
                LastName = "Tannen",
                Email = "biff@test.com",
                Major = "PE",
                AverageGrade = 75
            });
        }

        /// <summary>
        /// Adds a new student to the system
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool AddStudent(Student student)
        {
            var maxStudentId = students.Max(s => s.Id);
            var newStudentId = ++maxStudentId;

            students.Add(new Student
            {
                Id = newStudentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Major = student.Major,
                AverageGrade = student.AverageGrade
            });

            var latestMaxStudentId = students.Max(s => s.Id);

            return latestMaxStudentId == newStudentId;
        }

        /// <summary>
        /// removes a student from the system
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool DeleteStudent(Student student)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns all of the students currently in the system
        /// </summary>
        /// <returns></returns>
        public List<Student> GetAllStudents()
        {
            return students;
        }
    }
}
