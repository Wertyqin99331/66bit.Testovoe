namespace Frontend.Helpers;

public static class ProblemDetailsHelper
{
    public static Microsoft.AspNetCore.Mvc.ProblemDetails GetDefaultProblemDetails()
    {
        return new Microsoft.AspNetCore.Mvc.ProblemDetails() { Status = 500, Detail = "Что-то пошло не так" };
    }
}