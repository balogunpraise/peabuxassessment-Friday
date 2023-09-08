using Core.Entities;

namespace student_teacher_test.MockData
{
    public class TeacherMockData
    {
        public static IEnumerable<Teacher> GetTeachers()
        {
            return new List<Teacher>()
            {
                new Teacher
                {
                    Id = "3564-ace5637",
                    Name = "Test Name",
                    Surname = "Test Surname",
                    TeacherNumber = "09487637",
                    NationalIdNumber = "RA12345",
                    Salary = 2000,
                    DOB = new DateTime()
                },
                new Teacher
                {
                    Id = "3564-ace5637-45ff",
                    Name = "Test2 Name",
                    Surname = "Test2 Surname",
                    TeacherNumber = "09487637",
                    NationalIdNumber = "RA12645",
                    Salary = 4000,
                    DOB = new DateTime()
                }
            };

        }

        public static Teacher GetTeacherById(string Id)
        {
            return new Teacher()
            {
                Id = "3564-ace5637",
                Name = "Test Name",
                Surname = "Test Surname",
                TeacherNumber = "09487637",
                NationalIdNumber = "RA12345",
                Salary = 4000,
                DOB = new DateTime()
            };
        }

        public static Teacher AddTeacherEntity()
        {
            return new Teacher()
            {
                Name = "Test3 Name",
                Surname = "Test3 Surname",
                TeacherNumber = "09487637",
                NationalIdNumber = "RA12645",
                Salary = 3000,
                DOB = new DateTime()
            };
        }
    }
}
