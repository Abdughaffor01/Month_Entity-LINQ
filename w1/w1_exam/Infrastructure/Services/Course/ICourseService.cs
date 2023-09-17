using Domain;
namespace Infrastructure;
public interface ICourseService
{
    Task<Response<string>> AddCourseAsync(AddCourseDto course);
    Task<Response<string>> UpdateCourseAsync(UpdateCourseDto courseDto);
    Task<Response<string>> DeleteCourseAsync(int courseid);
    Task<Response<GetCourseDto>> GetCourseByIdAsync(int courseid);
    Task<Response<List<GetCourseDto>>> GetCoursesAsync();
}
