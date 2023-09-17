using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;
public class TeacherService : ITeacherService
{
    private readonly DataContext _dataContext;
    public TeacherService(DataContext dataContext) => _dataContext = dataContext;
    public async Task<Response<string>> AddTeacherAsync(AddTeacherDto teacher)
    {
        try
        {
            await _dataContext.Teathers.AddAsync(new Teather()
            {
                Name = teacher.Name,
                SurName = teacher.SurName,
                Position = teacher.Position,
                Experiens = teacher.Experiens
            });
            await _dataContext.SaveChangesAsync();
            return new Response<string>("Successfuly added teacher");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }

    public async Task<Response<string>> DeleteTeacherAsync(int teacherId)
    {
        try
        {
            var find = await _dataContext.Teathers.FindAsync(teacherId);
            if (find == null) return new Response<string>("not found");
            _dataContext.Teathers.Remove(find);
            await _dataContext.SaveChangesAsync();
            return new Response<string>("Successfuly deleted teacher");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }
    public async Task<Response<string>> UpdateTeacherAsync(UpdateTeacherDto teacher)
    {
        try
        {
            var find = await _dataContext.Teathers.FindAsync(teacher.Id);
            if (find == null) return new Response<string>("not found");
            find.Name = teacher.Name;
            find.SurName = teacher.SurName;
            find.Experiens = teacher.Experiens;
            find.Position = teacher.Position;
            _dataContext.Teathers.Update(find);
            await _dataContext.SaveChangesAsync();
            return new Response<string>("Successfuly updated teacher");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }

    public async Task<Response<GetTeacherDto>> GetTeacherByIdAsync(int teacherid)
    {
        try
        {
            var find = await _dataContext.Teathers.FirstOrDefaultAsync(t => t.Id == teacherid);
            if (find == null) return new Response<GetTeacherDto>("not found");
            return new Response<GetTeacherDto>(new GetTeacherDto()
            {
                Id = find.Id,
                Name = find.Name,
                SurName = find.SurName,
                Experiens = find.Experiens,
                Position = find.Position,
            });
        }
        catch (Exception ex)
        {
            return new Response<GetTeacherDto>(ex.Message);
        }
    }

    public async Task<Response<List<GetTeacherDto>>> GetTeachersAsync()
    {
        try
        {
            var find = await _dataContext.Teathers.Select(t => new GetTeacherDto()
            {
                Id = t.Id,
                Name = t.Name,
                SurName = t.SurName,
                Position = t.Position,
                Experiens = t.Experiens,
            }).ToListAsync();
            if (find.Count == 0) return new Response<List<GetTeacherDto>>("not found");
            return new Response<List<GetTeacherDto>>(find);
        }
        catch (Exception ex)
        {
            return new Response<List<GetTeacherDto>>(ex.Message);
        }
    }
}
