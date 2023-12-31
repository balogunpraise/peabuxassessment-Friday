﻿using Core.Entities;
using FluentAssertions;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using student_teacher_test.MockData;

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


        [Fact]
        public async Task GetStudents_ShouldReturnAList()
        {
            //Arrange
            _context.Students.AddRange(StudentMockData.GetAllStudents());
            _context.SaveChanges();
            var sut = new StudentRepository(_context);

            //Act
            var result = await sut.GetAllStudents();

            //Assert
            result.Should().HaveCount(StudentMockData.GetAllStudents().Count());
        }


        [Fact]
        public async Task AddNewStudent()
        {
            //Arrange
            _context.Students.AddRange(StudentMockData.GetAllStudents());
            _context.SaveChanges();

            var newStudent = StudentMockData.AddStudentEntity();
            var sut = new StudentRepository(_context);

            //Act
            await sut.AddStudent(newStudent);

            //Assert
            int expected = StudentMockData.GetAllStudents().Count() + 1; 
            _context.Students.Count().Should().Be(expected);
        }

        [Fact]
        public async Task AddNewStudent_ShouldReturnTrue()
        {
            //Arrange
            _context.Students.AddRange(StudentMockData.GetAllStudents());
            _context.SaveChanges();

            var newStudent = StudentMockData.AddStudentEntity();
            var sut = new StudentRepository(_context);

            //Act
            var response = await sut.AddStudent(newStudent);

            //Assert
            response.Should().BeTrue();
        }


        [Theory]
        [InlineData("3564-ace5637")]
        public async Task GetStudentById_ShouldProvideTheStudentIfAvailable(string id)
        {
            //Arrange
            _context.Students.AddRange(StudentMockData.GetAllStudents());
            _context.SaveChanges();
            var newStudent = StudentMockData.AddStudentEntity();
            var sut = new StudentRepository(_context);

            //Act
            var student = await sut.GetStudentById(id);

            //Assert
            student.Should().NotBeNull();
        }

        [Theory]
        [InlineData("3564-ace5637")]
        public async Task GetStudentById_ShouldReturnATypeOfStudent(string id)
        {
            //Arrange
            _context.Students.AddRange(StudentMockData.GetAllStudents());
            _context.SaveChanges();
            var newStudent = StudentMockData.AddStudentEntity();
            var sut = new StudentRepository(_context);

            //Act
            var student = await sut.GetStudentById(id);

            //Assert
            student.GetType().Should().Be(typeof(Student));
        }



        [Theory]
        [InlineData("3564-ace5637")]
        public async Task DeleteStudent_ShouldDeleteSuccessfully(string id)
        {
            //Arrange
            _context.Students.AddRange(StudentMockData.GetAllStudents());
            _context.SaveChanges();
            var newStudent = StudentMockData.AddStudentEntity();
            var sut = new StudentRepository(_context);

            //Act
            var isDeleted = await sut.DeleteStudent(id);

            //Assert
            isDeleted.Should().BeTrue();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
