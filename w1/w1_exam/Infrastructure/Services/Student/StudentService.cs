using Domain;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure;
public class StudentService : IStudentService
{
    private readonly DataContext _datacontext;
    public StudentService(DataContext dataContext) => _datacontext = dataContext;
    public async Task<Response<string>> AddStudentAsync(AddStudentDto student)
    {
        try
        {
            await _datacontext.Students.AddAsync(new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                FatherName = student.FatherName,
                BirthDate = student.BirthDate,
                Address = student.Address,
                Phone = student.Phone
            });
            await _datacontext.SaveChangesAsync();
            return new Response<string>("Successfuly added student");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }
    public async Task<Response<string>> UpdateStudentAsync(UpdateStudentDto student)
    {
        try
        {
            var find = await _datacontext.Students.FindAsync(student.Id);
            if (find == null) return new Response<string>("not found");
            find.FirstName = student.FirstName;
            find.LastName = student.LastName;
            find.FatherName = student.FatherName;
            find.BirthDate = student.BirthDate;
            find.Address = student.Address;
            find.Phone = student.Phone;
            _datacontext.Students.Update(find);
            await _datacontext.SaveChangesAsync();
            return new Response<string>("Successfuly updeted student");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }

    public async Task<Response<string>> DeleteStudentAsync(int studentId)
    {
        try
        {
            var find = await _datacontext.Students.FindAsync(studentId);
            if (find == null) return new Response<string>("not found");
            _datacontext.Students.Remove(find);
            await _datacontext.SaveChangesAsync();
            return new Response<string>("Successfuly deleted student");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }

    public async Task<Response<GetStudentDto>> GetStudentByIdAsync(int studentid)
    {
        try
        {
            var find = await _datacontext.Students.FirstOrDefaultAsync(s => s.Id == studentid);
            if (find == null) return new Response<GetStudentDto>("not found");
            return new Response<GetStudentDto>(new GetStudentDto()
            {
                Id = find.Id,
                FirstName = find.FirstName,
                LastName = find.LastName,
                FatherName = find.FatherName,
                BirthDate = (DateTime)find.BirthDate,
                Address = find.Address,
                Phone = find.Phone,
            });
        }
        catch (Exception ex)
        {
            return new Response<GetStudentDto>(ex.Message);
        }
    }

    public async Task<Response<List<GetStudentDto>>> GetStudentsAsync()
    {
        try
        {
            var find = await _datacontext.Students.Select(s => new GetStudentDto()
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                FatherName = s.FatherName,
                BirthDate = (DateTime)s.BirthDate,
                Address = s.Address,
                Phone = s.Phone,
            }).ToListAsync();
            if (find.Count == 0) return new Response<List<GetStudentDto>>("not found");
            return new Response<List<GetStudentDto>>(find);
        }
        catch (Exception ex)
        {
            return new Response<List<GetStudentDto>>(ex.Message);
        }
    }

}
