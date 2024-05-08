using BuisinessLayer.CustomException;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BuisinessLayer.ApplicationExcceptionHandler
{
    public class UserExceptionHandler: ExceptionFilterAttribute
    {
        private readonly Dictionary<Type, Func<ExceptionContext, IActionResult>> _exceptionHandlers;
        public UserExceptionHandler()
        {
            _exceptionHandlers = new Dictionary<Type, Func<ExceptionContext, IActionResult>>
            {
                {typeof(UserNotFoundException),HandleUserNotFoundException },
                {typeof(PasswordMissMatchException),HandlePasswordMissmatchException }
            };
        }
        public override void OnException(ExceptionContext context)
        {
            if (_exceptionHandlers.TryGetValue(context.Exception.GetType(), out var handler))
            {
                context.Result = handler(context);
            }
            else
            {
                HandleUnknownException(context);
            }
        }
        private IActionResult HandleUserNotFoundException(ExceptionContext context)
        {
            return HandleException(context, "UserNotFoundException", StatusCodes.Status404NotFound);
        }
        private IActionResult HandlePasswordMissmatchException(ExceptionContext context)
        {
            return HandleException(context, "PassworMissmatchException", StatusCodes.Status401Unauthorized);
        }



        private IActionResult HandleException(ExceptionContext context, string key, int statusCode)
        {
            context.ModelState.AddModelError(key, context.Exception.Message);
            ValidationProblemDetails problemdetail = new ValidationProblemDetails(context.ModelState);
            problemdetail.Status = statusCode;
            return new ObjectResult(problemdetail) { StatusCode = statusCode };
        }
        private IActionResult HandleUnknownException(ExceptionContext context)
        {
            context.ModelState.AddModelError("unknown exception in notes ", $"{context.Exception.Message}  stacktrace==> {context.Exception.StackTrace}");
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(context.ModelState);
            problemDetails.Status = StatusCodes.Status422UnprocessableEntity;
            return new UnprocessableEntityObjectResult(problemDetails);
        }
    }
}
