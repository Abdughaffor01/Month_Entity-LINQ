using Domain;
using Dapper;
using Infrastructure.Context;

namespace Infrastructure;

public class CategoryService : ICategoryService
{
    private readonly DataContext _dataContext;
    public CategoryService(DataContext dataContext)=>_dataContext = dataContext;

    public async Task<Response<string>> AddCategoryAsync(AddCategoryDto addCategoryDto)
    {
        try
        {
            using var con=_dataContext.CreateConnection();
            string sql = @"insert into category(category_name)values(@Name);";
            var res = await con.ExecuteAsync(sql,addCategoryDto);
            if (res == 0) return new Response<string>("500");
            return new Response<string>("Successfuly added category");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }
    public async Task<Response<string>> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
    {
        try
        {
            using var con= _dataContext.CreateConnection();
            string sql = @"update category set category_name=@Name where id=@Id;";
            var res= await con.ExecuteAsync(sql,updateCategoryDto);
            if(res==0) return new Response<string>("500");
            return new Response<string>("Successfuly added category");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }
    public async Task<Response<string>> DeleteCategoryAsync(int categoryId)
    {
        try
        {
            using var con = _dataContext.CreateConnection();
            string sql = $"delete from category where id=@categoryId;";
            var res=await con.ExecuteAsync(sql,categoryId);
            if (res == 0) return new Response<string>("not found");
            return new Response<string>("Successfuly deleted category");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }
    public async Task<Response<List<GetCategoryDto>>> GetCategoriesAsync()
    {
        try
        {
            using var con=_dataContext.CreateConnection();
            string sql = "select id as Id,category_name as Name from category;";
            var res=await con.QueryAsync<GetCategoryDto>(sql);
            if (res == null) return new Response<List<GetCategoryDto>>("not found");
            return new Response<List<GetCategoryDto>>("Successfuly founded categories",res.ToList());
        }
        catch (Exception ex)
        {
            return new Response<List<GetCategoryDto>>(ex.Message);
        }
    }
    public async Task<Response<GetCategoryDto>> GetCategoryByIdAsync(int categoryId)
    {
        try
        {
            using var con = _dataContext.CreateConnection();
            string sql = $"select id as Id, category_name as Name from category where id={categoryId};";
            var res=await con.QueryFirstOrDefaultAsync<GetCategoryDto>(sql);
            if (res == null) return new Response<GetCategoryDto>("not found");
            return new Response<GetCategoryDto>("Successfuly founded category", res);
        }
        catch (Exception ex)
        {
            return new Response<GetCategoryDto>(ex.Message);
        }
    }
}
