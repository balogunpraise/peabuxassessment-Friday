using System.ComponentModel.DataAnnotations;

namespace student_teacher_project.Dtos
{
    public class CreateTeacherDto
    {
        [Required(ErrorMessage = "National Id is a required field")]
        public string NationalIdNumber { get; set; }

        [Required]
        public string Title { get; set; }

        [Required(ErrorMessage = "Name is a required field")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is a required field")]
        public string Surname { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string TeacherNumber { get; set; }

        public decimal Salary { get; set; }
    }

    public class TeacherResponseDto
    {
        public string Id { get; set; }
        public string NationalIdNumber { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TeacherNumber { get; set; }

        public decimal Salary { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}
