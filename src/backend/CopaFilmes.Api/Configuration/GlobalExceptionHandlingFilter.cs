using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CopaFilmes.Api.Configuration
{
  public class GlobalExceptionHandlingFilter : IExceptionFilter
  {
    public void OnException(ExceptionContext context)
    {
      var request = context.HttpContext.Request;
      context.Result = ConfigureResponse(HttpStatusCode.InternalServerError, context.Exception.Message);
    }

    private static IActionResult ConfigureResponse(HttpStatusCode httpStatusCode, string message)
    {
      var jsonResult = new JsonResult(new Response<object>(httpStatusCode, message));
      jsonResult.StatusCode = (int)httpStatusCode;
      return jsonResult;
    }
  }
}