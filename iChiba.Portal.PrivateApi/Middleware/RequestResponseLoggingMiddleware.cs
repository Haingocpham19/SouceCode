using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Core.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace iChiba.Portal.PrivateApi.Middleware
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public RequestResponseLoggingMiddleware(ILogger<RequestResponseLoggingMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        private static async Task<LogMetadata> FormatRequest(HttpRequest request)
        {
            var log = new LogMetadata
            {
                RequestTimestamp = DateTime.Now,
                RequestUri = $"{request.Scheme}://{request.Host}{request.Path} {request.QueryString}",
                IpAddress = $"{request.Host.Host}"
            };

            var body = request.Body;

            //This line allows us to set the reader for the request back at the beginning of its stream.
            //request.EnableRewind();
            request.EnableBuffering();

            //We now need to read the request stream.  First, we create a new byte[] with the same length as the request stream...
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];

            //...Then we copy the entire request stream into the new buffer.
            await request.Body.ReadAsync(buffer, 0, buffer.Length);

            //We convert the byte[] into a string using UTF8 encoding...
            var bodyAsText = Encoding.UTF8.GetString(buffer);

            //..and finally, assign the read body back to the request body, which is allowed because of EnableRewind()
            request.Body = body;

            log.RequestBody = $"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
            return log;
        }

        private static async Task<LogMetadata> FormatResponse(LogMetadata log, HttpResponse response)
        {
            log.ResponseTimestamp = DateTime.Now;
            log.ResponseStatusCode = response.StatusCode;

            //We need to read the response stream from the beginning...
            response.Body.Seek(0, SeekOrigin.Begin);

            //...and copy it into a string
            var text = await new StreamReader(response.Body).ReadToEndAsync();

            //We need to reset the reader for the response so that the client can read it.
            response.Body.Seek(0, SeekOrigin.Begin);

            //Return the string for the response, including the status code (e.g. 200, 404, 401, etc.)
            log.ResponseBody = $"{text}";
            return log;
        }
        
        public async Task Invoke(HttpContext context)
        {
            //This line allows us to set the reader for the request back at the beginning of its stream.
            context.Request.EnableBuffering();

            //First, get the incoming request
            var request = await FormatRequest(context.Request);

            //Copy a pointer to the original response body stream
            var originalBody = context.Response.Body;
            try
            {
                //Create a new memory stream...
                using (var memStream = new MemoryStream())
                {
                    //...and use that for the temporary response body
                    context.Response.Body = memStream;

                    //Continue down the Middleware pipeline, eventually returning to this class
                    context.Request.Body.Position = 0;
                    await _next(context);

                    //Format the response from the server
                    var response = await FormatResponse(request, context.Response);

                    //Send log
                    SendToLog(response);

                    //Copy the contents of the new memory stream (which contains the response) to the original stream, which is then returned to the client.
                    if (context.Response.StatusCode != 204)
                        await memStream.CopyToAsync(originalBody);
                }
            }
            finally
            {
                context.Response.Body = originalBody;
            }
        }

        private void SendToLog(LogMetadata logMetadata)
        {
            _logger.LogWarning(Serialize.JsonSerializeObject(logMetadata));
        }
    }

    public static class RequestResponseLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestResponseLoggingMiddleware>();
        }
    }

    public class LogMetadata
    {
        public DateTime? RequestTimestamp { get; set; }
        public string RequestUri { get; set; }
        public string RequestBody { get; set; }
        public string IpAddress { get; set; }
        public DateTime? ResponseTimestamp { get; set; }
        public string ResponseBody { get; set; }
        public int ResponseStatusCode { get; set; }
        public int TimeLapse
        {
            get
            {
                if (RequestTimestamp != null && ResponseTimestamp != null)
                    return (int)ResponseTimestamp?.Subtract((DateTime)RequestTimestamp).Milliseconds;
                return 0;
            }
        }
    }
}
