using Microsoft.EntityFrameworkCore;
using Something3.Core.Services;
using Something3.Core.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Something3.Database.Services
{
    public class ClassLibraryPersistence : IClassLibraryPersistence
    {
        private AppDbContext ctx;

        public ClassLibraryPersistence(AppDbContext ctx)
        {
            this.ctx = ctx;
        }

        public List<Core.Model.Something3> GetSomething3List()
        {
            return ctx.Something3s.ToList();
        }

        public List<Something3WithId> GetSomething3WithIdList()
        {
            return ctx.Something3s.Select(x => new Something3WithId()
            {
                Id = EF.Property<int>(x, "Id"),
                FullName = x.FullName
            }).ToList();
        }

        public void SaveSomething3(Core.Model.Something3 something3)
        {
            ctx.Something3s.Add(something3);
            ctx.SaveChanges();
        }
    }
}
