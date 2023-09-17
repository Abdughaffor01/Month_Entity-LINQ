using Domain;
namespace Infrastructure;
public interface IStudentService
{
    Task<Response<string>> AddStudentAsync(AddStudentDto student);
    Task<Response<string>> UpdateStudentAsync(UpdateStudentDto student);
    Task<Response<string>> DeleteStudentAsync(int studentId);
    Task<Response<List<GetStudentDto>>> GetStudentsAsync();
    Task<Response<GetStudentDto>> GetStudentByIdAsync(int studentid);

}
