using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Task<bool> DeleteStudent(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(string id)
        {
            return await _context.Students.FindAsync(id);
        }

        public Task<bool> UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
