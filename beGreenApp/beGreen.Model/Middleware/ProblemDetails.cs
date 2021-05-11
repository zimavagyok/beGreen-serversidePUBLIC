namespace beGreen.Model.Middleware
{
    public class ProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public ProblemDetails()
        {
        }

        public ProblemDetails(string detail, int status, string title)
        {
            Detail = detail;
            Status = status;
            Title = title;
        }

        public ProblemDetails(string detail, string instance, int? status, string title, string type)
        {
            Detail = detail;
            Instance = instance;
            Status = status;
            Title = title;
            Type = type;
        }
    }
}
