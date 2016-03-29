using System;
using Microsoft.AspNet.Builder;
using Microsoft.Extensions.Logging;

namespace MiddlewareDemo.Middleware
{
    /// <summary>
    /// I use one class to hold all the extension methods that add my custom middleware modules to the 
    /// ApplicationBuilder class.
    /// </summary>
    public static class CustomMiddlewarExtensions
    {
        /// <summary>
        /// *POI Step 2
        /// This extension method does two things.
        /// 1.  Gives us a way to add our custom middleware class to the Http Pipeline.
        /// 2.  Injects our dependencies into the ApplicationBuilder class.
        /// </summary>
        /// <param name="builder">Required to extend the ApplicationBuilder class.</param>
        /// <param name="loggerFactory">The LoggerFactory object from the Startup.Configure() method.</param>
        /// <param name="responseTimer">An instantiated ResponseTimer object.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseResponseTimer(this IApplicationBuilder builder, ILoggerFactory loggerFactory, ResponseTimer responseTimer)
        {
            //This method will accept a parameter array but I always explicitly define parameter arrays.
            return builder.UseMiddleware<ResponseTimeLogger>(new object[] { loggerFactory, responseTimer });
        }
    }
}
