using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly RepositoryContext _context;
        private readonly ILogger<RepositoryContext> _logger;

        public StudentRepository(RepositoryContext context, ILogger<RepositoryContext> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<bool> AddStudent(Student student)
        {
            await _context.AddAsync(student);
            var succeeded = _context.SaveChangesAsync().Result == 1;
            return succeeded;
        }

        public async Task<bool> DeleteStudent(string id)
        {
            var studentToDelete = await GetStudentById(id);
            if (studentToDelete != null)
            {
                _context.Students.Remove(studentToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(string id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<bool> UpdateStudent(string id, Student student)
        {
            var studentToUpdate = await GetStudentById(id);
            if (studentToUpdate != null)
            {
                studentToUpdate.Name = student.Name ?? studentToUpdate.Name;
                studentToUpdate.Surname = student.Surname ?? studentToUpdate.Surname;
                studentToUpdate.StudentNumber = student.StudentNumber ?? studentToUpdate.StudentNumber;
                studentToUpdate.NationalIdNumber = student.NationalIdNumber ?? studentToUpdate.NationalIdNumber;
                studentToUpdate.UpdatedAt = DateTimeOffset.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
