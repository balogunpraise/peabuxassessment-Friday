using System.ComponentModel.DataAnnotations;

namespace student_teacher_project.Dtos
{
    public class StudentRequestDto
    {
        [Required]
        public string NationalIdNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]  
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string StudentNumber { get; set; }
    }

    public class StudentResponseDto 
    {
        public string Id { get; set; }
        public string NationalIdNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string StudentNumber { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }

}
