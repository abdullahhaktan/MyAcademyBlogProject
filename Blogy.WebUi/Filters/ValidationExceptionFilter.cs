using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Blogy.WebUi.Filters
{
    public class ValidationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is not ValidationException validationException)
            {
                return;
            }

            foreach (var error in validationException.Errors)
            {
                context.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            var actionName = context.RouteData.Values["action"].ToString();

            context.Result = new ViewResult { ViewName = actionName };

            context.ExceptionHandled = true;

        }
    }
}
