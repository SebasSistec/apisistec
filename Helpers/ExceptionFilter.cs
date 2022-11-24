using apisistec.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace apisistec.Helpers
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        DefaultResponses response = new();
        private ILoggerManager _logs;
        public ExceptionFilter(ILoggerManager logs)
        {
            _logs=logs;
        }
        public override void OnException(ExceptionContext context)
        {
            _logs.LogError($"Error: {context.Exception.Message}");
            context.Result = new ObjectResult(response.ErrorResponse($"{context.Exception.Message}", ""))
            {
                StatusCode = 500
            };
        }
    }
}
