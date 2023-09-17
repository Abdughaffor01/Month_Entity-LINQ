using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;
public class CourseService : ICourseService
{
    private readonly DataContext _dataContext;
    public CourseService(DataContext dataContext) => _dataContext = dataContext;
    public async Task<Response<string>> AddCourseAsync(AddCourseDto course)
    {
        try
        {
            await _dataContext.Courses.AddAsync(new Course()
            {
                Title = course.Title,
                Description = course.Description,
                Fee = course.Fee,
                HasDiscount = false
            });
            var res = await _dataContext.SaveChangesAsync();
            return new Response<string>("Successfuly added course");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }

    public async Task<Response<string>> UpdateCourseAsync(UpdateCourseDto courseDto)
    {
        try
        {
            var find = await _dataContext.Courses.FindAsync(courseDto.Id);
            if (find == null) return new Response<string>("not found");
            find.Title = courseDto.Title;
            find.Description = courseDto.Description;
            find.Fee = courseDto.Fee;
            _dataContext.Courses.Update(find);
            await _dataContext.SaveChangesAsync();
            return new Response<string>("Successfuly updated course");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }
    public async Task<Response<string>> DeleteCourseAsync(int courseid)
    {
        try
        {
            var find = await _dataContext.Courses.FindAsync(courseid);
            if (find == null) return new Response<string>("not found");
            _dataContext.Courses.Remove(find);
            await _dataContext.SaveChangesAsync();
            return new Response<string>("Successuly deleted course");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }

    public async Task<Response<GetCourseDto>> GetCourseByIdAsync(int courseid)
    {
        try
        {
            var find = await _dataContext.Courses.FindAsync(courseid);
            if (find == null) return new Response<GetCourseDto>("not found");
            return new Response<GetCourseDto>(new GetCourseDto()
            {
                Id = find.Id,
                Title = find.Title,
                Description = find.Description,
                Fee = find.Fee
            });
        }
        catch (Exception ex)
        {
            return new Response<GetCourseDto>(ex.Message);
        }
    }

    public async Task<Response<List<GetCourseDto>>> GetCoursesAsync()
    {
        try
        {
            var find = await _dataContext.Courses.Select(c => new GetCourseDto()
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                Fee = c.Fee
            }).ToListAsync();
            if (find.Count == 0) return new Response<List<GetCourseDto>>("not found");
            return new Response<List<GetCourseDto>>(find);
        }
        catch (Exception ex)
        {
            return new Response<List<GetCourseDto>>(ex.Message);
        }
    }
}
