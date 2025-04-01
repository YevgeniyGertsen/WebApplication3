using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication3.AppFilter
{
    public class IEFilterAttribute : Attribute, IResourceFilter
    {
        //сразу после завершения этапа [Stage].
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            throw new NotImplementedException();
        }

        //вызывается непосредственно перед этапом Stage
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            string userAgent = context.HttpContext.Request
                .Headers["user-agent"].ToString();

            if(userAgent.Contains("Mozilla"))
            {
                context.Result = new ContentResult
                {
                    Content = "Ваш браузер устарел!"
                };
            }
        }
    }
}
