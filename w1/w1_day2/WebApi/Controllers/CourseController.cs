using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi;
[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;
    public CourseController(ICourseService courseService) => _courseService = courseService;

    [HttpPost("AddCourseAsync")]
    public async Task<Response<string>> AddCourseAsync([FromForm] AddCourseDto addCourseDto) => await _courseService.AddCourseAsync(addCourseDto);

    [HttpDelete("DeleteCourseAsync")]
    public async Task<Response<string>> DeleteCourseAsync(int id)=>await _courseService.DeleteCourseAsync(id);

    [HttpPut("UpdateCourseAsync")]
    public async Task<Response<string>> UpdateCourseAsync(UpdateCourseDto updateCourseDto)=>await _courseService.UpdateCourseAsync(updateCourseDto);

    [HttpGet("GetCourseByIdAsync")]
    public async Task<Response<GetCourseDto>> GetCourseByIdAsync(int id)=>await _courseService.GetCourseByIdAsync(id);

    [HttpGet("GetCourses")]
    public async Task<Response<List<GetCourseDto>>> GetCourses()=>await _courseService.GetCourses();

}
