using Domain.Exceptions;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace Infrastructure.Filters
{
    public class ErrorFilter : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public ErrorFilter()
        {
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(CoreException), HandleCoreException },
                { typeof(ApplicationException), HandleApplicationException },
                { typeof(InfrastructureException), HandleInfrastructureException }
            };
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            HandleUnknownException(context);
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            ProblemDetails details = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An error occurred while processing your request."
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }

        private void HandleCoreException(ExceptionContext context)
        {
            CoreException exception = context.Exception as CoreException;

            ProblemDetails details = new ProblemDetails()
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = exception.Message,
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }

        private void HandleApplicationException(ExceptionContext context)
        {
            CoreException exception = context.Exception as CoreException;

            ProblemDetails details = new ProblemDetails()
            {
                Status = StatusCodes.Status400BadRequest,
                Title = exception.Message,
                Detail = exception.InnerException?.Message
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status400BadRequest
            };

            context.ExceptionHandled = true;
        }

        private void HandleInfrastructureException(ExceptionContext context)
        {
            CoreException exception = context.Exception as CoreException;

            ProblemDetails details = new ProblemDetails()
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = exception.Message,
                Detail = exception.InnerException?.Message
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}