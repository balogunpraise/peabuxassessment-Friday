using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Presentation.Controllers;
using student_teacher_test.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_teacher_test.Systems.Services
{
    public class TestStudentRepository : IDisposable
    {
        private readonly RepositoryContext _context;
        public TestStudentRepository()
        {
            var options = new DbContextOptionsBuilder<RepositoryContext>()
                .UseInMemoryDatabase(databaseName: new Guid().ToString())
                .Options;
            _context = new RepositoryContext(options);
            _context.Database.EnsureCreated();
        }

        public async Task GetStudents_ShouldReturnAList()
        {
            
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
