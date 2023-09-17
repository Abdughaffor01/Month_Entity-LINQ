using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;
public class PostService : IPostService
{
    private readonly DataContext _dataContext;
    public PostService(DataContext dataContext)=>_dataContext=dataContext;
    public async Task<Response<string>> AddPostAsync(AddPostDto post)
    {
        try
        {
            await _dataContext.Posts.AddAsync(new Post()
            {
                Title = post.Title,
                Description = post.Description,
                CreateAt = DateTime.UtcNow,
                Vote = 0
            });
            await _dataContext.SaveChangesAsync();
            return new Response<string>("Successfuly posted");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }

    public async Task<Response<string>> DeletePostAsync(int postId)
    {
        try
        {
            var find=await _dataContext.Posts.FindAsync(postId);
            if (find == null) return new Response<string>("not found");
            _dataContext.Posts.Remove(find);
            await _dataContext.SaveChangesAsync();
            return new Response<string>("Successfuly deleted post");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }
    public async Task<Response<string>> UpdatePostAsync(UpdatePostDto post)
    {
        try
        {
            var find = await _dataContext.Posts.FindAsync(post.Id);
            if (find == null) return new Response<string>("not found");
            find.Title = post.Title;
            find.Description = post.Description;
            _dataContext.Posts.Update(find);
            await _dataContext.SaveChangesAsync();
            return new Response<string>("Successfuly updated post");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }

    public async Task<Response<GetPostDto>> GetPostByIdAsync(int postId)
    {
        try
        {
            var find = await _dataContext.Posts.FirstOrDefaultAsync(p => p.Id == postId);
            if (find == null) return new Response<GetPostDto>("not found");
            return new Response<GetPostDto>(new GetPostDto() { 
                Id = find.Id,
                Title = find.Title,
                Description = find.Description,
                CreateAt = find.CreateAt,
                Vote=find.Vote,
            });
        }
        catch (Exception ex)
        {
            return new Response<GetPostDto>(ex.Message);
        }
    }

    public async Task<Response<List<GetPostDto>>> GetPostsAsync()
    {
        try
        {
            var find = await _dataContext.Posts.Select(p=>new GetPostDto() { 
                Id=p.Id,
                Title=p.Title,
                Description=p.Description,
                CreateAt=p.CreateAt,
                Vote=p.Vote,
            }).ToListAsync();
            if (find.Count == 0) return new Response<List<GetPostDto>>("not found");
            return new Response<List<GetPostDto>>(find);
        }
        catch (Exception ex)
        {
            return new Response<List<GetPostDto>>(ex.Message);
        }
    }

}
