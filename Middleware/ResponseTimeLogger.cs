using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Logging;

namespace MiddlewareDemo.Middleware
{
    /// <summary>
    /// *POI Step 1
    /// This is the class that defines our custom middleware.  In Step 2 we use dependency injection to 
    /// make the LoggerFactory and ResponseTimer objects available in this class.
    /// 
    /// This middleware module just calculates the time it takes for the server to respond to a request.
    /// Then displays that information in the output window.
    /// </summary>
    public class ResponseTimeLogger
    {
        private readonly RequestDelegate next;
        private readonly ILoggerFactory loggerFactory;
        private readonly ResponseTimer responseTimer;

        /// <summary>
        /// *POI
        /// Microsoft's implementation of IApplicationBuilder injects the RequestDelegate object.  So
        /// that parameter is required and it needs to be the first parameter in the constructor of
        /// all middleware classes.  The other parameters are objects we inject in Step 2.
        /// </summary>
        /// <param name="next">Represents the next module in the http pipeline.</param>
        /// <param name="loggerFactory">The LoggerFactory object from the Startup.Configure() method.</param>
        /// <param name="responseTimer">An instantiated ResponseTimer object.</param>
        public ResponseTimeLogger(RequestDelegate next, ILoggerFactory loggerFactory, ResponseTimer responseTimer)
        {
            this.next = next;
            this.loggerFactory = loggerFactory;
            this.responseTimer = responseTimer;
        }

        /// <summary>
        /// *POI
        /// This is the method that is called by the framework when the execution of the Http pipeline
        /// reaches our middleware module. 
        /// </summary>
        /// <param name="context">A required parameter that the framework supplies.</param>
        public async Task Invoke(HttpContext context)
        {
            ILogger logger;
            string message;

            logger = this.loggerFactory.CreateLogger("ResponseLogger");
            this.responseTimer.startTime = DateTime.Now;

            //*POI
            //This is how you call the next module in the Http pipeline.
            //The code above this call executes during the request.
            //The code below this call executes during the response.
            await this.next.Invoke(context);

            message = "****************************************************************************" + Environment.NewLine +
                      $"Request URL: {context.Request.Path}" + Environment.NewLine +
                      $"Remote IP: {context.Connection.RemoteIpAddress}" + Environment.NewLine +
                      $"Response Time: {this.responseTimer.GetResponseTime(DateTime.Now)}" + Environment.NewLine +
                       "****************************************************************************";

            //Display the message in the output window.
            logger.LogInformation(Environment.NewLine + message);
        }
    }
}
