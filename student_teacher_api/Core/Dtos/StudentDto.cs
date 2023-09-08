using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class CreateStudentDto
    {
        [Required(ErrorMessage = "The name field is a required field")]
        [RegularExpression("/^[a-zA-Z]+$/g")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname field is a required field")]
        [RegularExpression("/^[a-zA-Z]+$/g")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "National ID is a required field")]
        public string NationalIdNumber { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string StudentNumber { get; set; }
    }

    public class UpdateStudentDto 
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string NationalIdNumber { get; set; }
        public DateTime DOB { get; set; }
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
