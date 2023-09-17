using Dapper;
using Domain;

namespace Infrastructure;
public class CourseService : ICourseService
{
    private readonly DataContext _dataContext;
    private readonly IFileService _fileService;
    public CourseService(DataContext dataContext, IFileService fileService)
    {
        _dataContext = dataContext;
        _fileService = fileService;
    }
    public async Task<Response<string>> AddCourseAsync(AddCourseDto addCourseDto)
    {
        try
        {
            using var con = _dataContext.CreateConnection();
            string filename = string.Empty;
            if (addCourseDto.Logo != null) filename = await _fileService.AddFileAsync(addCourseDto.Logo, "images");
            string sql = "insert into courses(name,description,price,duration,duration_type,start_date,logo)" +
                @$"values(@Name,@Description,@Price,@Duration,@DurationType,'{DateTime.Now.Date}','{filename}');";
            var response = await con.ExecuteAsync(sql, addCourseDto);
            return response == 0 ? new Response<string>("500") : new Response<string>("Successfuly added course with images");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }

    public async Task<Response<string>> DeleteCourseAsync(int id)
    {
        try
        {
            using var con=_dataContext.CreateConnection();
            var images = (await con.QueryAsync<string>($"select logo from courses where id={id};")).ToList();
            if (images != null) foreach (var image in images) await _fileService.DeleteFile(image, "images");
            var res = await con.ExecuteAsync($"delete from courses where id={id};");
            return res == 0 ? new Response<string>("not found") : new Response<string>("Successfuly deleted course");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }

    public async Task<Response<string>> UpdateCourseAsync(UpdateCourseDto updateCourseDto)
    {
        try
        {
            using var con = _dataContext.CreateConnection();
            string sql = @"update courses set name=@Name,description=@Description,price=@Price,duration=@Duration,duration_type=@DurationType where id=@Id;";
            var res=await con.ExecuteAsync(sql, updateCourseDto);
            return res == 0 ? new Response<string>("not found") : new Response<string>("Successfuly updated course");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }

    public async Task<Response<GetCourseDto>> GetCourseByIdAsync(int id)
    {
        try
        {
            using var con = _dataContext.CreateConnection();
            var res = await con.QueryFirstOrDefaultAsync<GetCourseDto>($"select id as Id, name as Name,description as Description,price as Price,duration as Duration,duration_type as DurationType,start_date as StartDate,logo as FileName from courses where id={id};");
            return res == null ? new Response<GetCourseDto>("not found") : new Response<GetCourseDto>(res);
        }
        catch (Exception ex)
        {
            return new Response<GetCourseDto>(ex.Message);
        }
    }

    public async Task<Response<List<GetCourseDto>>> GetCourses()
    {
        try
        {
            using var con = _dataContext.CreateConnection();
            var res = await con.QueryAsync<GetCourseDto>($"select id as Id, name as Name,description as Description,price as Price,duration as Duration,duration_type as DurationType,start_date as StartDate,logo as FileName from courses;");
            return res == null ? new Response<List<GetCourseDto>>("not found") : new Response<List<GetCourseDto>>(res.ToList());
        }
        catch (Exception ex)
        {
            return new Response<List<GetCourseDto>>(ex.Message);
        }
    }
}
