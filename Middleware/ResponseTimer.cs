using System;

namespace MiddlewareDemo.Middleware
{
    /// <summary>
    /// *POI
    /// Used to calculate the time it takes for the server to respond to a request.  We will
    /// use dependency injection to access this class in the custom middleware.  There are
    /// simpler ways to calculate the duration of a response.  I'm using this class just to 
    /// show an example of how to inject one of your classes into a middleware module.
    /// </summary>
    public class ResponseTimer
    {
        public DateTime startTime { get; set; }

        /// <summary>
        /// Sets the time that a request enters the Http pipeline.
        /// </summary>
        /// <param name="startTime">The time that a request enters the Http pipeline.</param>
        public void SetRequestStart(DateTime startTime)
        {
            this.startTime = startTime;
        }

        /// <summary>
        /// Calculates the time it took for the server to process the request.
        /// </summary>
        /// <param name="endTime">The time that the response is sent to the client.</param>
        /// <returns>The difference between the start time and end time in seconds and milliseconds.</returns>
        public string GetResponseTime(DateTime endTime)
        {
            TimeSpan diff;

            diff = endTime.Subtract(this.startTime);
            
            return $"{diff.Seconds} seconds {diff.Milliseconds} milliseconds";
        }
    }
}
