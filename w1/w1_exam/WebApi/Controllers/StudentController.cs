using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    public StudentController(IStudentService studentService) => _studentService = studentService;

    [HttpGet("GetStudentByIdAsync")]
    public async Task<Response<GetStudentDto>> GetStudentByIdAsync(int studentid) => await _studentService.GetStudentByIdAsync(studentid);

    [HttpGet("GetStudentsAsync")]
    public async Task<Response<List<GetStudentDto>>> GetStudentsAsync() => await _studentService.GetStudentsAsync();

    [HttpPost("AddStudentAsync")]
    public async Task<Response<string>> AddStudentAsync(AddStudentDto student) => await _studentService.AddStudentAsync(student);

    [HttpPut("UpdateStudentAsync")]
    public async Task<Response<string>> UpdateStudentAsync(UpdateStudentDto student) => await _studentService.UpdateStudentAsync(student);

    [HttpDelete("DeleteStudentAsync")]
    public async Task<Response<string>> DeleteStudentAsync(int studentId) => await _studentService.DeleteStudentAsync(studentId);
}
