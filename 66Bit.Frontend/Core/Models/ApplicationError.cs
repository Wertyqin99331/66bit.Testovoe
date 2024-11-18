using Microsoft.AspNetCore.Mvc;

namespace Core.Models;

public class ApplicationError(string title, string detail)
{
    public string Title { get; set; } = title;
    public string Detail { get; set; } = detail;
    
    public ProblemDetails ToProblemDetails(int status)
    {
        return new ProblemDetails
        {
            Status = status,
            Title = this.Title,
            Detail = this.Detail
        };
    }
}