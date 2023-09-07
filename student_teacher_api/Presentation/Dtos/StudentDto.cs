using System.ComponentModel.DataAnnotations;

namespace Presentation.Dtos
{
    public class CreateStudentDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string NationalIdNumber { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string StudentNumber { get; set; }
    }

    public class StudentResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string NationalIdNumber { get; set; }
        public DateTime DOB { get; set; }
        public string StudentNumber { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
