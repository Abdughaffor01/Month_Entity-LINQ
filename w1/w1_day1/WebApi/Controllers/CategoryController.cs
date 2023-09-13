using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebApi;
[ApiController]
[Route("[controller]")]
public class CategoryController:ControllerBase
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)=>_categoryService = categoryService;

    [HttpPost("AddCategoryAsync")]
    public async Task<Response<string>> AddCategoryAsync([FromForm]AddCategoryDto addCategoryDto)=>await _categoryService.AddCategoryAsync(addCategoryDto);

    [HttpPut("UpdateCategoryAsync")]
    public async Task<Response<string>> UpdateCategoryAsync([FromForm]UpdateCategoryDto updateCategoryDto)=>await _categoryService.UpdateCategoryAsync(updateCategoryDto);

    [HttpDelete("DeleteCategoryAsync")]
    public async Task<Response<string>> DeleteCategoryAsync(int categoryId)=>await _categoryService.DeleteCategoryAsync(categoryId);

    [HttpGet("GetCategoriesAsync")]
    public async Task<Response<List<GetCategoryDto>>> GetCategoriesAsync()=>await _categoryService.GetCategoriesAsync();

    [HttpGet("GetCategoryAsync")]
    public async Task<Response<GetCategoryDto>> GetCategoryAsync(int categoryId)=>await _categoryService.GetCategoryByIdAsync(categoryId);   

}
