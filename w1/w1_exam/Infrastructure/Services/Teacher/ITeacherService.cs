using Domain;

namespace Infrastructure;
public interface ITeacherService
{
    Task<Response<string>> AddTeacherAsync(AddTeacherDto teacher);
    Task<Response<string>> UpdateTeacherAsync(UpdateTeacherDto teacher);
    Task<Response<string>> DeleteTeacherAsync(int teacherId);
    Task<Response<List<GetTeacherDto>>> GetTeachersAsync();
    Task<Response<GetTeacherDto>> GetTeacherByIdAsync(int teacherid);
}
