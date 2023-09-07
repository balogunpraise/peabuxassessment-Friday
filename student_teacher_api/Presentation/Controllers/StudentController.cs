using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
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


        #region Command

        [HttpPost("student")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateStudent(CreateStudentDto studentDto)
        {
            var student = _mapper.Map<CreateStudentDto, Student>(studentDto);
            var response = await _studentRepository.AddStudent(student);
            return response ? Ok(new ApiResponse(200, "Student added successfully"))
                : BadRequest(new ApiErrorResponse(400));
        }

        [HttpPut("student/{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateStudent(string id, UpdateStudentDto studentDto)
        {
            var student = _mapper.Map<UpdateStudentDto, Student>(studentDto);
            var response = await _studentRepository.UpdateStudent(id, student);
            return response ? Ok(new ApiResponse(200, "Student updated")) : BadRequest(new ApiErrorResponse(400));
        }


        [HttpDelete("student/{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteStudent(string id)
        {
            var response = await _studentRepository.DeleteStudent(id);
            return response ? Ok(new ApiResponse(200, "Student Deleted")) : BadRequest(new ApiErrorResponse(400));
        }

        #endregion


        #region Query

        [HttpGet("student/{id}")]
        [ProducesResponseType(typeof(ApiResponse<StudentResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetStudent(string id)
        {
            var student = await _studentRepository.GetStudentById(id);
            if(student != null)
            {
                var response = _mapper.Map<Student, StudentResponseDto>(student);
                return Ok(new ApiResponse<StudentResponseDto>(response, 200));
            }
            return NotFound(new ApiErrorResponse(404));
        }


        [HttpGet("student/{id}")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<StudentResponseDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetStudents()
        {
            var students = await _studentRepository.GetAllStudents();
            var response = _mapper.Map<IEnumerable<Student>, IEnumerable<StudentResponseDto>>(students);
            return Ok(new ApiResponse<IEnumerable<StudentResponseDto>>(response, 200));
        }

        #endregion
    }
}
