using Ataoge;

namespace Microsoft.AspNetCore.Mvc.Filters
{
    public class AspNetCoreExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
		{
            if (context.Exception is CoreException)
            {
                context.ExceptionHandled = true;
                context.Result = new ContentResult() {
                    Content = string.Format("Action:{0},错误消息: {1}",context.ActionDescriptor.DisplayName, context.Exception.Message)

                };
            }
		}
    }
}