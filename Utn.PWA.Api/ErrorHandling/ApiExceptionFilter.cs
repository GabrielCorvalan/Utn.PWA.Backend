using System.Data.SqlClient;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Utn.PWA.Helpers;

public class ApiExceptionFilter : ExceptionFilterAttribute
{
    public const int SqlServerViolationOfUniqueIndex = 2601;
    public const int SqlServerViolationOfUniqueConstraint = 2627;
    public override void OnException(ExceptionContext context)
    {
        HttpStatusCode status = HttpStatusCode.InternalServerError;

        var exceptionType = context.Exception.GetType();
        var dbUpdateEx = context.Exception as DbUpdateException;
        var sqlEx = dbUpdateEx?.InnerException as SqlException;
        // if (exceptionType is MyCustomException) //Checking for my custom exception type
        // {
        //     message = context.Exception.Message;
        // }

        // if (sqlEx != null)
        // {
        //     //This is a DbUpdateException on a SQL database
 
        //     if (sqlEx.Number == SqlServerViolationOfUniqueIndex || sqlEx.Number == SqlServerViolationOfUniqueConstraint)
        //     {
        //         context.Result = new ObjectResult(new ApiResponse((int)status, "La propiedad ya existe en la base de datos"));
        //     }

        //     else if (sqlEx.Number == 547)
        //     {
        //         context.Result = new ObjectResult(new ApiResponse((int)status, "La propiedad (Foreign key) no existe en la base de datos"));
        //     }
        // }
        // else 
        // {
            var exceptionMessage = context.Exception.InnerException.Message;
            context.ExceptionHandled = true;
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            context.Result = new ObjectResult(new ApiResponse((int)status, exceptionMessage));
        // }

    }
}