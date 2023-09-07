using AutoMapper;
using Core.Dtos;
using Core.Entities;
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


        [HttpPost("teacher")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddTeacher(CreateTeacherDto teacherDto)
        {
            var teacher = _mapper.Map<CreateTeacherDto, Teacher>(teacherDto);
            var succeeded = await _repository.AddTeacher(teacher);
            return succeeded ? Ok(new ApiResponse(200, "Adding teacher was successful")) 
                : BadRequest(new ApiErrorResponse(400));
        }



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



        [HttpPut("teacher/{id}")]
        public async Task<ActionResult> UpdateTeacher(string id, CreateTeacherDto teacherDto)
        {

        }
    }
}
