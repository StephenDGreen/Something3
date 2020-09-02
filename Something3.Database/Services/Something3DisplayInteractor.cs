using Microsoft.EntityFrameworkCore;
using Something3.Core.Services;
using Something3.Core.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Something3.Database.Services
{
    public class Something3DisplayInteractor : ISomething3DisplayInteractor
    {
        private readonly IClassLibraryPersistence persistence;
        private readonly AppDbContext ctx;

        public Something3DisplayInteractor(IClassLibraryPersistence persistence)
        {
            this.persistence = persistence;
        }

        public Something3DisplayInteractor(IClassLibraryPersistence persistence, AppDbContext ctx)
        {
            this.persistence = persistence;
            this.ctx = ctx;
        }

        public List<Core.Model.Something3> GetSomething3List()
        {
            return persistence.GetSomething3List();
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
