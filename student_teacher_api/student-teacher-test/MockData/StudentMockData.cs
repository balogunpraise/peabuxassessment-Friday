using Core.Entities;

namespace student_teacher_test.MockData
{
    public class StudentMockData
    {
        public static IEnumerable<Student> GetAllStudents()
        {
            return new List<Student>() 
            {
                new Student
                {
                    Id = new Guid().ToString(),
                    Name = "Test Name",
                    Surname = "Test Surname",
                    StudentNumber = "09487637",
                    NationalIdNumber = "RA12345",
                    DOB = new DateTime()
                },
                new Student
                {
                    Id = new Guid().ToString(),
                    Name = "Test2 Name",
                    Surname = "Test2 Surname",
                    StudentNumber = "09487637",
                    NationalIdNumber = "RA12645",
                    DOB = new DateTime()
                }
            };

        }

        public static Student GetStudentById(string Id)
        {
            return new Student()
            {
                Id = "3564-ace5637",
                Name = "Test Name",
                Surname = "Test Surname",
                StudentNumber = "09487637",
                NationalIdNumber = "RA12345",
                DOB = new DateTime()
            };
        }
    }
}
