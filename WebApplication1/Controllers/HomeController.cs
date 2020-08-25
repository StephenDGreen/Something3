using ClassLibrary1.Application.Services;
using ClassLibrary1.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly Something3Interactor something3Interactor;
        private readonly Something3DisplayInteractor something3DisplayInteractor;

        public HomeController(Something3Interactor something3Interactor, Something3DisplayInteractor something3DisplayInteractor)
        {
            this.something3Interactor = something3Interactor;
            this.something3DisplayInteractor = something3DisplayInteractor;
        }
        [HttpPost]
        public void Create([FromQuery] string fullName)
        {
            something3Interactor.CreateSomething3(fullName);
        }
        [HttpGet]
        public List<Something3> GetList()
        {
            return something3DisplayInteractor.GetSomething3List().ToList();
        }
    }
}
