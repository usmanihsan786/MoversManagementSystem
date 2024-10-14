using Microsoft.AspNetCore.Http;

namespace MoversManagementSystem.ExceptionHandler;

public class ExceptionsHandlerMiddleWare
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionsHandlerMiddleWare> _logger;

    public ExceptionsHandlerMiddleWare(RequestDelegate next , ILogger<ExceptionsHandlerMiddleWare> logger)
    {
        
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
     {
        try
        {
            await _next(context);   

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var errorResponse = new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Internal Server Error",
                };
                
          await context.Response.WriteAsJsonAsync(errorResponse); 


        }

     }
}
