using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Wrappers;

namespace Presentation.Controllers
{
    public class StudentController : BaseApiController
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }



        [HttpGet("studend")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateStudent(CreateStudentDto studentDto)
        {
            var student = _mapper.Map<CreateStudentDto, Student>(studentDto);
            var response = await _studentRepository.AddStudent(student);
            return response ? Ok(new ApiResponse(200, "Student added successfully"))
                : BadRequest(new ApiErrorResponse(400));
        }


    }
}
