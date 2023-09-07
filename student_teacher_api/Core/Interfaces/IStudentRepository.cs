using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IStudentRepository
    {
        Task<bool> AddStudent(Student student);
        Task<Student> GetStudentById(string id);
        Task<IEnumerable<Student>> GetAllStudents();
        Task<bool> DeleteStudent(string id);
        Task<bool> UpdateStudent(Student student);
    }
}
