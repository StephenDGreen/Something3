using ClassLibrary1.Core;
using ClassLibrary1.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1.Database
{
    public class ClassLibraryPersistence : IClassLibraryPersistence
    {
        private AppDbContext ctx;

        public ClassLibraryPersistence(AppDbContext ctx)
        {
            this.ctx = ctx;
        }

        public List<Something3> GetSomething3List()
        {
            return ctx.Something3s.ToList();
        }

        public void SaveSomething3(Something3 something3)
        {
            ctx.Something3s.Add(something3);
            ctx.SaveChanges();
        }
    }
}
