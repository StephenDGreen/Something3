using ClassLibrary1.Core;
using ClassLibrary1.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISomething3Factory something3Factory;

        public HomeController(ISomething3Factory something3Factory)
        {
            this.something3Factory = something3Factory;
        }
        [HttpPost]
        public Something3 Create([FromQuery] string fullName)
        {
            return something3Factory.Create(fullName);
        }
    }
}
