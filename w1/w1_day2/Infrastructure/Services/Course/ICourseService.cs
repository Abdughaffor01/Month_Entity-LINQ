using Domain;
namespace Infrastructure;
public interface ICourseService
{
    Task<Response<string>> AddCourseAsync(AddCourseDto addCourseDto);
    Task<Response<string>> DeleteCourseAsync(int id);
    Task<Response<string>> UpdateCourseAsync(UpdateCourseDto updateCourseDto);
    Task<Response<GetCourseDto>> GetCourseByIdAsync(int id);
    Task<Response<List<GetCourseDto>>> GetCourses();
}
