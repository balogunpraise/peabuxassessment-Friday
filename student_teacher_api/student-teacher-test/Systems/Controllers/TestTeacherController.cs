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
    public class TestTeacherController
    {
        private static IMapper _mapper;
        public TestTeacherController()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new TeacherProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }



        [Fact]
        public async Task GetTeachers_ShouldReturn200Status()
        {
            //Arrange
            var teacherRepo = new Mock<ITeacherRepository>();
            teacherRepo.Setup(x => x.GetAllTeachers()).ReturnsAsync(TeacherMockData.GetTeachers());
            var sut = new TeacherController(teacherRepo.Object, _mapper);
            //Act

            var result = await sut.GetTeachers();
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Theory]
        [InlineData("3564-ace5637")]
        public async Task GetStudent_ShouldReturn200Status(string id)
        {

            //Arrange
            var teacherRepo = new Mock<ITeacherRepository>();
            teacherRepo.Setup(x => x.GetTeacherById(id)).ReturnsAsync(TeacherMockData.GetTeacherById(id));
            var sut = new TeacherController(teacherRepo.Object, _mapper);
            //Act

            var result = await sut.GetTeacher(id);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }


        
    }
}
