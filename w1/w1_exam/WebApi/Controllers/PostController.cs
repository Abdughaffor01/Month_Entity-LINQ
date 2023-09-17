using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;
[Route("[controller]")]
public class PostController:ControllerBase
{
    private readonly IPostService _postService;
    public PostController(IPostService postService)=>_postService = postService;

    [HttpGet("GetPostsAsync")]
    public async Task<Response<List<GetPostDto>>> GetPostsAsync()=>await _postService.GetPostsAsync();

    [HttpGet("GetPostByIdAsync")]
    public async Task<Response<GetPostDto>> GetPostByIdAsync(int postId)=>await _postService.GetPostByIdAsync(postId);

    [HttpPost("AddPostAsync")]
    public async Task<Response<string>> AddPostAsync(AddPostDto post)=>await _postService.AddPostAsync(post);

    [HttpDelete("DeletePostAsync")]
    public async Task<Response<string>> DeletePostAsync(int postId)=>await _postService.DeletePostAsync(postId);

    [HttpPut("UpdatePostAsync")]
    public async Task<Response<string>> UpdatePostAsync(UpdatePostDto post)=>await _postService.UpdatePostAsync(post);  
}
