using Something3.Application.Services;
using Something3.Core.Model;
using Something3.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Something3.UI.Controllers
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
        public void Create([FromQuery] string fullName)
        {
            something3Interactor.CreateSomething3(fullName);
        }
        [HttpGet]
        [Route("api/things")]
        public List<Something3WithId> GetList()
        {
            return GetThings();
        }

        [HttpGet]
        [Route("api/things/{id:int?}")]
        public Something3WithId Get(int id)
        {
            return GetThings().FirstOrDefault(y => y.Id == id);
        }

        public List<Something3WithId> GetThings()
        {
            return ctx.Something3s.Select(x => new Something3WithId()
            {
                Id = EF.Property<int>(x, "Id"),
                FullName = x.FullName
            }).ToList();
        }
    }
}
