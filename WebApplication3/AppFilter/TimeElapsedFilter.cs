using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace WebApplication3.AppFilter
{
    public class TimeElapsedFilter : Attribute, IActionFilter
    {
        private Stopwatch timer;
        //после
        public void OnActionExecuted(ActionExecutedContext context)
        {
            timer.Stop();
            string result = "Time elapsed: " + timer.Elapsed.TotalMilliseconds;
        }
        //вызывается непосредственно перед этапом Stage
        public void OnActionExecuting(ActionExecutingContext context)
        {
            timer = Stopwatch.StartNew();
        }
    }
}
