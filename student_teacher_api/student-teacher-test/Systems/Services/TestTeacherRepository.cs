using FluentAssertions;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using student_teacher_test.MockData;

namespace student_teacher_test.Systems.Services
{
    public class TestTeacherRepository
    {
        private readonly RepositoryContext _context;
        public TestTeacherRepository()
        {
            var options = new DbContextOptionsBuilder<RepositoryContext>()
                .UseInMemoryDatabase(databaseName: new Guid().ToString())
                .Options;
            _context = new RepositoryContext(options);
            _context.Database.EnsureCreated();
        }

        [Fact]
        public async Task GetTeachers_ShouldReturnAList()
        {
            //Arrange
            _context.Teachers.AddRange(TeacherMockData.GetTeachers());
            _context.SaveChanges();
            var sut = new TeacherRepository(_context);

            //Act
            var result = await sut.GetAllTeachers();

            //Assert
            result.Should().HaveCount(StudentMockData.GetAllStudents().Count());
        }

        [Fact]
        public async Task AddNewTeacher_ShouldAddSuccessfully()
        {
            //Arrange
            _context.Teachers.AddRange(TeacherMockData.GetTeachers());
            _context.SaveChanges();

            var newTeacher = TeacherMockData.AddTeacherEntity();
            var sut = new TeacherRepository(_context);

            //Act
            await sut.AddTeacher(newTeacher);

            //Assert
            int expected = TeacherMockData.GetTeachers().Count() + 1;
            _context.Teachers.Count().Should().Be(expected);
        }


        [Theory]
        [InlineData("3564-ace5637")]
        public async Task GetTeacherById_ShouldProvideTheTeacherIfAvailable(string id)
        {
            //Arrange
            _context.Teachers.AddRange(TeacherMockData.GetTeachers());
            _context.SaveChanges();

            var newTeacher = TeacherMockData.AddTeacherEntity();
            var sut = new TeacherRepository(_context);

            //Act
            var teacher = await sut.GetTeacherById(id);

            //Assert
            teacher.Should().NotBeNull();
        }

        [Theory]
        [InlineData("3564-ace5637")]
        public async Task DeleteTeacher_ShouldDeleteSuccessfully(string id)
        {
            //Arrange
            _context.Teachers.AddRange(TeacherMockData.GetTeachers());
            _context.SaveChanges();

            var newTeacher = TeacherMockData.AddTeacherEntity();
            var sut = new TeacherRepository(_context);

            //Act
            var isDeleted = await sut.DeleteTeacher(id);

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
