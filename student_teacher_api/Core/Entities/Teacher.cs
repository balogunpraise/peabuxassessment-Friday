namespace Core.Entities
{
    public class Teacher : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string NationalIdNumber { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public string TeacherNumber { get; set; }
        public decimal Salary { get; set; }
    }
}
