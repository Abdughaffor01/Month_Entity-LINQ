using Domain;
namespace Infrastructure;
public interface IPostService
{
    Task<Response<string>> AddPostAsync(AddPostDto post);
    Task<Response<string>> DeletePostAsync(int postId);
    Task<Response<string>> UpdatePostAsync(UpdatePostDto post);
    Task<Response<List<GetPostDto>>> GetPostsAsync();
    Task<Response<GetPostDto>> GetPostByIdAsync(int postId);

}
