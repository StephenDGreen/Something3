using ClassLibrary1.Application.Services;
using ClassLibrary1.Core.Model;
using ClassLibrary1.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace WebApplication1.Controllers
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
        public void Create([FromQuery] string fullName)
        {
            something3Interactor.CreateSomething3(fullName);
        }
        [HttpGet]
        [Route("api/things")]
        public List<Something3WithId> GetList()
        {
            var ret = ctx.Something3s.Select(x => new Something3WithId()
            {
                Id = EF.Property<int>(x, "Id"),
                FullName = x.FullName
            }).ToList();
            return ret;
        }
        [HttpGet]
        [Route("api/things/{id:int?}")]
        public Something3WithId Get(int id)
        {
            var ret = ctx.Something3s.Select(x => new Something3WithId()
            {
                Id = EF.Property<int>(x, "Id"),
                FullName = x.FullName
            }).FirstOrDefault(y => y.Id == id);
            return ret;
        }
    }
}
