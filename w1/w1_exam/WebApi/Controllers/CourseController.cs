using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;
[Route("[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;
    public CourseController(ICourseService courseService) => _courseService = courseService;

    [HttpGet("GetCoursesAsync")]
    public async Task<Response<List<GetCourseDto>>> GetCoursesAsync() => await _courseService.GetCoursesAsync();

    [HttpGet("GetCourseByIdAsync")]
    public async Task<Response<GetCourseDto>> GetCourseByIdAsync(int courseid) => await _courseService.GetCourseByIdAsync(courseid);

    [HttpPost("AddCourseAsync")]
    public async Task<Response<string>> AddCourseAsync(AddCourseDto course) => await _courseService.AddCourseAsync(course);

    [HttpPut("UpdateCourseAsync")]
    public async Task<Response<string>> UpdateCourseAsync(UpdateCourseDto courseDto) => await _courseService.UpdateCourseAsync(courseDto);

    [HttpDelete("DeleteCourseAsync")]
    public async Task<Response<string>> DeleteCourseAsync(int courseid) => await _courseService.DeleteCourseAsync(courseid);
}
