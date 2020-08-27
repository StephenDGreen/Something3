using Something3.Application.Services;
using Something3.Core.Model;
using Something3.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Something3.Application.ViewModel;

namespace Something3.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISomething3Interactor something3Interactor;
        private readonly ISomething3DisplayInteractor something3DisplayInteractor;
        private readonly AppDbContext ctx;

        public HomeController(ISomething3Interactor something3Interactor, ISomething3DisplayInteractor something3DisplayInteractor, AppDbContext ctx)
        {
            this.something3Interactor = something3Interactor;
            this.something3DisplayInteractor = something3DisplayInteractor;
            this.ctx = ctx;
        }

        [HttpPost]
        [Route("api/things")]
        public ActionResult Create([FromForm] string fullName)
        {
            if(fullName.Length < 1)
                return GetAll();

            something3Interactor.CreateSomething3(fullName);
            return GetAll();
        }

        [HttpGet]
        [Route("api/things")]
        public ActionResult GetList()
        {
            return GetAll();
        }

        private ActionResult GetAll()
        {
            var result = something3DisplayInteractor.GetThings();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/things/{id:int?}")]
        public ActionResult Get(int id)
        {
            var result = something3DisplayInteractor.GetThings().FirstOrDefault(y => y.Id == id);
            return Ok(result);
        }
    }
}
