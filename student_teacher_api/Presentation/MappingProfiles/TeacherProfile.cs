using AutoMapper;
using Core.Dtos;
using Core.Entities;

namespace Presentation.MappingProfiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<CreateTeacherDto, Teacher>();
            CreateMap<Teacher, TeacherResponseDto>();
        }
    }
}
