using AutoMapper;
using Core.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.Controllers;
using Presentation.MappingProfiles;
using student_teacher_test.MockData;

namespace student_teacher_test.Systems.Controllers
{
    public class TestStudentController
    {
        private static IMapper _mapper;
        public TestStudentController()
        {
            if(_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new StudentProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public async Task GetStudents_ShouldReturn200Status()
        {
            //Arrange
            var studentRepo = new Mock<IStudentRepository>();
            studentRepo.Setup(x => x.GetAllStudents()).ReturnsAsync(StudentMockData.GetAllStudents());
            var sut = new StudentController(studentRepo.Object, _mapper);
            //Act

            var result = await sut.GetStudents();
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200); 
        }


        [Theory]
        [InlineData("3564-ace5637")]
        public async Task GetStudent_ShouldReturn200Status(string id)
        {

            //Arrange
            var studentRepo = new Mock<IStudentRepository>();
            studentRepo.Setup(x => x.GetStudentById(id)).ReturnsAsync(StudentMockData.GetStudentById(id));
            var sut = new StudentController(studentRepo.Object, _mapper);
            //Act

            var result = await sut.GetStudent(id);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
 
    }
}
