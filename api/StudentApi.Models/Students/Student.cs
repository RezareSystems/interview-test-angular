namespace StudentApi.Models.Students
{
    public class Student
    {
        public long StudentId { get; set; } = 0;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Major { get; set; } = string.Empty;

        public double Average { get; set; } = 0;
    }
}
