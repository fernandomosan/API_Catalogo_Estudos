using ApiCatalogo.Repository;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ApiCatalogo.GraphQL
{
    public class TesteGraphQLMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUnitOfWork _context;

        public TesteGraphQLMiddleware(RequestDelegate next, IUnitOfWork context)
        {
             _next = next;
            _context = context;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.StartsWithSegments("/graphql"))
            {
                using (var stream = new StreamReader(httpContext.Request.Body))
                {
                    var query = await stream.ReadToEndAsync();

                    if (!String.IsNullOrWhiteSpace(query))
                    {
                        var schema = new Schema
                        {
                            Query = new CategoriaQuery(_context)
                        };

                        var result = await new DocumentExecuter().ExecuteAsync(option =>
                        {
                            option.Query = query;
                            option.Schema = schema;
                        });
                        await WriteResult(httpContext, result);
                    }
                }
            }
            else
            {
                await _next(httpContext);
            }
        }

        private async Task WriteResult(HttpContext httpContext, ExecutionResult result)
        {
            var json = JsonConvert.SerializeObject(result);

            httpContext.Response.StatusCode = 200;
            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsync(json);
        }
    }
}
