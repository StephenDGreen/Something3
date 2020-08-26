using Something3.Core;
using Something3.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace Something3.Database
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

        public void SaveSomething3(Core.Model.Something3 something3)
        {
            ctx.Something3s.Add(something3);
            ctx.SaveChanges();
        }
    }
}
