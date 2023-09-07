using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        public Task<bool> AddTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTeacher(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Teacher>> GetAllTeachers()
        {
            throw new NotImplementedException();
        }

        public Task<Teacher> GetTeacherById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStudent(Teacher student)
        {
            throw new NotImplementedException();
        }
    }
}
