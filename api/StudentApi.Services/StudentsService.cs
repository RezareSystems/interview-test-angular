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
                FirstName = "Marty",
                LastName = "McFly",
                Email = "back.future@test.com",
                Major = "History",
                AverageGrade=85
            });

            students.Add(new Student {
                FirstName = "Emmett",
                LastName = "Brown",
                Email = "dr.brown@test.com",
                Major = "Physics",
                AverageGrade = 50.5
            });

            students.Add(new Student
            {
                FirstName = "Biff",
                LastName = "Tannen",
                Email = "biff@test.com",
                Major = "PE",
                AverageGrade = 49
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
            //validating whether the same student is alredy available
            var results = students.FindAll(x => x.FirstName == student.FirstName
                    && x.LastName == student.LastName && student.Major == x.Major);
            if (results.Count > 0)
            {
                return false;
            }

            students.Add(new Student
            {
                Email = student.Email,
                AverageGrade = student.AverageGrade,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Major = student.Major
            });

            return true;
        }

        /// <summary>
        /// removes a student from the system
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool DeleteStudent(Student student)
        {
            var results = students.FindAll(x => x.FirstName == student.FirstName
                    && x.LastName == student.LastName
                    && student.Major == x.Major
                    && student.Email == x.Email
                    && student.AverageGrade == x.AverageGrade);
            if (results.Count == 0)
            {
                return false;
            }

            students.Remove(new Student
            {
                Email = student.Email,
                AverageGrade = student.AverageGrade,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Major = student.Major
            });

            return true;
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
