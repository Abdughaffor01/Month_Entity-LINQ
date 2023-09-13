using Domain;
namespace Infrastructure;
public interface ICategoryService
{
    Task<Response<string>> AddCategoryAsync(AddCategoryDto addCategoryDto);
    Task<Response<string>> DeleteCategoryAsync(int categoryId);
    Task<Response<string>> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
    Task<Response<List<GetCategoryDto>>> GetCategoriesAsync();
    Task<Response<GetCategoryDto>> GetCategoryByIdAsync(int categoryId);

}
