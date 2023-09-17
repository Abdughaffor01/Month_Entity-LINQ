using Microsoft.AspNetCore.Http;

namespace Domain;
public class AddCourseDto : BaseCourse
{
    public IFormFile? Logo { get; set; }
}
