using interview_test_angular.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interview_test_angular.Services
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
                AverageGrade = "75"
            }); ;

            students.Add(new Student
            {
                Id = 2,
                FirstName = "Emmett",
                LastName = "Brown",
                Email = "dr.brown@test.com",
                Major = "Physics",
                AverageGrade = "45"
            });

            students.Add(new Student
            {
                Id = 3,
                FirstName = "Biff",
                LastName = "Tannen",
                Email = "biff@test.com",
                Major = "PE",
                AverageGrade = "90"
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
            var idCount = students.Max(x => x.Id);

            students.Add(new Student
            {
                Id = idCount + 1,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Major = student.Major,
                AverageGrade = student.AverageGrade
            });

            var getLatest = students.Max(x => x.Id);

            if (idCount != getLatest)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// removes a student from the system
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool DeleteStudent(Student student)
        {
            //throw new NotImplementedException();
            var deleteID = students.Find(x => x.Id == student.Id);

            if (deleteID != null && deleteID.Id > 0)
            {
                students.Remove(deleteID);
                return true;
            }
            else
            {
                return false;
            }
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