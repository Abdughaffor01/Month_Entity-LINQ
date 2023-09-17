using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;
[Route("[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _teacherService;
    public TeacherController(ITeacherService teacherService) => _teacherService = teacherService;

    [HttpGet("GetTeachersAsync")]
    public async Task<Response<List<GetTeacherDto>>> GetTeachersAsync() => await _teacherService.GetTeachersAsync();

    [HttpGet("GetTeacherByIdAsync")]
    public async Task<Response<GetTeacherDto>> GetTeacherByIdAsync(int teacherid) => await _teacherService.GetTeacherByIdAsync(teacherid);

    [HttpPost("AddTeacherAsync")]
    public async Task<Response<string>> AddTeacherAsync(AddTeacherDto teacher) => await _teacherService.AddTeacherAsync(teacher);

    [HttpPut("UpdateTeacherAsync")]
    public async Task<Response<string>> UpdateTeacherAsync(UpdateTeacherDto teacher) => await _teacherService.UpdateTeacherAsync(teacher);

    [HttpDelete("DeleteTeacherAsync")]
    public async Task<Response<string>> DeleteTeacherAsync(int teacherId) => await _teacherService.DeleteTeacherAsync(teacherId);
}
