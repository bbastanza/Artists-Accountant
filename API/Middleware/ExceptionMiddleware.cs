using System;
using System.Threading.Tasks;
using API.Models;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (UserValidationException ex)
            {
                Console.WriteLine($"{ex.GetType()}\n{ex.Message}\nPath {ex.Path}.{ex.Method}");
                context.Response.StatusCode = 460;
                context.Response.Headers.Add("content-type", "application/json");
                await context.Response.WriteAsync(new ArtistExceptionModel(ex).ToString());
            }
            catch (ExistingUserException ex)
            {
                Console.WriteLine($"{ex.GetType()}\n{ex.Message}\nPath {ex.Path}.{ex.Method}");
                context.Response.StatusCode = 461;
                context.Response.Headers.Add("content-type", "application/json");
                await context.Response.WriteAsync(new ArtistExceptionModel(ex).ToString());
            }
            catch (NonExistingUserException ex)
            {
                Console.WriteLine($"{ex.GetType()}\n{ex.Message}\nPath {ex.Path}.{ex.Method}");
                context.Response.StatusCode = 462;
                context.Response.Headers.Add("content-type", "application/json");
                await context.Response.WriteAsync(new ArtistExceptionModel(ex).ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType()}\n{ex.Message}\n{ex.StackTrace}");
                context.Response.StatusCode = 500;
                context.Response.Headers.Add("content-type", "application/json");
                await context.Response.WriteAsync(new DefaultExceptionModel().ToString());
            }
        }
    }
}