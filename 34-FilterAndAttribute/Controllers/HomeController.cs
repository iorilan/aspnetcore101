using Filters.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers {

   // [Message("This is the Controller-Scoped Filter", Order = 10)]
    public class HomeController : Controller {

        [ServiceFilter(typeof(DiagnosticsFilter))]  
         [Message("This is the First Action-Scoped Filter")]
        // [Message("This is the Second Action-Scoped Filter", Order = -1)]
        public ViewResult Index() => View("Message",
            "This is the Index action on the Home controller");
        
    }
}
