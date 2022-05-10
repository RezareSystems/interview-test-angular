using StudentApi.Models.Students;
using System;
using System.Collections.Generic;

namespace StudentApi.Services
{
    public class StudentsService : IStudentsService
    {
        public List<Student> students = new List<Student>();

        public StudentsService()
        {
            students.Add(new Student
            {
                StudentId = 1,
                FirstName = "Marty",
                LastName = "McFly",
                Email = "back.future@test.com",
                Major = "History",
                Average = 50
            });

            students.Add(new Student
            {
                StudentId = 2,
                FirstName = "Emmett",
                LastName = "Brown",
                Email = "dr.brown@test.com",
                Major = "Physics",
                Average = 60
            });

            students.Add(new Student
            {
                StudentId = 3,
                FirstName = "Biff",
                LastName = "Tannen",
                Email = "biff@test.com",
                Major = "PE",
                Average = 70
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
            students.Add(student);
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
            return students.Remove(student);
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
