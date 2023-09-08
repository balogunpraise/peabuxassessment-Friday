using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.Wrappers;

namespace Presentation.Controllers
{
    public class TeacherController : BaseApiController
    {
        private readonly ITeacherRepository _repository;
        private readonly IMapper _mapper;
        public TeacherController(ITeacherRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #region Command

        [HttpPost("teacher")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddTeacher(CreateTeacherDto teacherDto)
        {
            var teacher = _mapper.Map<CreateTeacherDto, Teacher>(teacherDto);
            teacher.Title = Enum.GetValues<TitleEnum>().First(x => (int)x == teacherDto.Title).ToString();
            var succeeded = await _repository.AddTeacher(teacher);
            return succeeded ? Ok(new ApiResponse(200, "Adding teacher was successful")) 
                : BadRequest(new ApiErrorResponse(400));
        }


        [HttpPut("teacher/{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateTeacher(string id, UpdateTeacherDto teacherDto)
        {
            var teacher = _mapper.Map<UpdateTeacherDto, Teacher>(teacherDto);
            var response = await _repository.UpdateTeacher(id, teacher);
            return response ? Ok(new ApiResponse(200, "Teacher updated")) : BadRequest(new ApiErrorResponse(400));
        }


        [HttpDelete("teacher/{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteTeacher(string id)
        {
            var response = await _repository.DeleteTeacher(id);
            return response ? Ok(new ApiResponse(200, "Teacher Deleted")) : BadRequest(new ApiErrorResponse(400));
        }


        #endregion


        #region Query

        [HttpGet("teacher/{id}")]
        [ProducesResponseType(typeof(ApiResponse<Teacher>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetTeacher(string id)
        {
            var teacher = await _repository.GetTeacherById(id);
            if(teacher != null)
            {
                var response = _mapper.Map<Teacher, TeacherResponseDto>(teacher);
                return Ok(new ApiResponse<TeacherResponseDto>(response, 200));
            }
            return NotFound(new ApiErrorResponse(404));
        }


        [HttpGet("teacher")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<Teacher>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetTeachers()
        {
            var teachers = await _repository.GetAllTeachers();
            var response = _mapper.Map<IEnumerable<Teacher>, IEnumerable<TeacherResponseDto>>(teachers);
            return Ok(new ApiResponse<IEnumerable<TeacherResponseDto>>(response, 200));
        }

        #endregion
    }
}
