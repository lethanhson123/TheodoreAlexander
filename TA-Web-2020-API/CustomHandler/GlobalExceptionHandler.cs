using BL.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using TA_Web_2020_API.Helper;

namespace TA_Web_2020_API.CustomHandler
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public virtual Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            return HandleAsyncCore(context, cancellationToken);
        }
        public virtual Task HandleAsyncCore(ExceptionHandlerContext context,
                                      CancellationToken cancellationToken)
        {
            HandleCore(context);
            return Task.FromResult(0);
        }

        public virtual void HandleCore(ExceptionHandlerContext context)
        {
            var code = HttpStatusCode.InternalServerError;
            var exception = context.Exception;
            if(exception is NotFoundException)
            {
                code = HttpStatusCode.NotFound;
            }
            else if(exception is BadRequestException)
            {
                code = HttpStatusCode.BadRequest;
            }
            context.Result = new GenerateResponeHelper<string>(exception.Message, false, context.ExceptionContext.Request, code);
        }
    }
}