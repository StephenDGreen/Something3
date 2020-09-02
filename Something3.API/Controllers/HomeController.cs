using Microsoft.AspNetCore.Mvc;
using Something3.Database;
using Something3.Database.Services;
using System.Linq;

namespace Something3.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly Something3Interactor something3Interactor;
        private readonly Something3DisplayInteractor something3DisplayInteractor;
        private readonly AppDbContext ctx;

        public HomeController(Something3Interactor something3Interactor, Something3DisplayInteractor something3DisplayInteractor, AppDbContext ctx)
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
