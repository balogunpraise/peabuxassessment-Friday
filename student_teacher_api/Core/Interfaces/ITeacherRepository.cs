using Core.Entities;

namespace Core.Interfaces
{
    public interface ITeacherRepository
    {
        Task<bool> AddTeacher(Teacher teacher);
        Task<Teacher> GetTeacherById(string id);
        Task<IEnumerable<Teacher>> GetAllTeachers();
        Task<bool> DeleteTeacher(string id);
        Task<bool> UpdateTeacher(string id, Teacher teacher);
    }
}
