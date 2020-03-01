using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Infrastructure {

    public class DiagnosticsFilter : IAsyncResultFilter {
        private IFilterDiagnostics diagnostics;

        public DiagnosticsFilter(IFilterDiagnostics diags) {
            diagnostics = diags;
        }

        public async Task OnResultExecutionAsync(
                ResultExecutingContext context,
                ResultExecutionDelegate next) {

            await next();
            System.Console.WriteLine($"[diagnostic filter ]test==> {System.DateTime.Now}");
           // var message = $"test- {System.DateTime.Now}";
            //foreach (string message in diagnostics?.Messages) {
                // byte[] bytes = Encoding.UTF8
                //     .GetBytes($"<div>from diag filter  {message}</div>");
                // await context.HttpContext.Response.Body
                //     .WriteAsync(bytes, 0, bytes.Length);
            //}
        }
    }
}
