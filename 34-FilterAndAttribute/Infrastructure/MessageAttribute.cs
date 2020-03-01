using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Infrastructure {

    public class MessageAttribute : ResultFilterAttribute {
        private string message;

        public MessageAttribute(string msg) {
            message = msg;
        }

        public override void OnResultExecuting(ResultExecutingContext context) {
           // WriteMessage(context, $"<div>Before Result:{message} {System.DateTime.Now}</div>");
            System.Console.WriteLine($"[message attribute]test==> {System.DateTime.Now}");
            base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context) {
          //  WriteMessage(context, $"<div>After Result:{message} {System.DateTime.Now}</div>");
            base.OnResultExecuted(context);
        }

        private void WriteMessage(FilterContext context, string msg) {
            byte[] bytes = Encoding.UTF8
                .GetBytes($"<div>{msg}</div>");
            context.HttpContext.Response
                .Body.Write(bytes, 0, bytes.Length);
        }
    }
}
