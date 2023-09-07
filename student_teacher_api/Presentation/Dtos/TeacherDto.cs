using System.ComponentModel.DataAnnotations;

namespace Presentation.Dtos
{
    public class CreateTeacherDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string NationalIdNumber { get; set; }

        [Required]  
        public string Title { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string TeacherNumber { get; set; }
        public decimal Salary { get; set; }
    }

    public class TeacherResponseDto 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string NationalIdNumber { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public string TeacherNumber { get; set; }
        public decimal Salary { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }

}
