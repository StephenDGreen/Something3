using Microsoft.EntityFrameworkCore;
using Something3.Core.Services;
using Something3.Core.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Something3.API.Services
{
    public class Something3DisplayInteractor : ISomething3DisplayInteractor
    {
        private readonly IClassLibraryPersistence persistence;

        public Something3DisplayInteractor(IClassLibraryPersistence persistence)
        {
            this.persistence = persistence;
        }

        public List<Core.Model.Something3> GetSomething3List()
        {
            return persistence.GetSomething3List();
        }

        public List<Something3WithId> GetThings()
        {
            return persistence.GetSomething3WithIdList();
        }
    }
}
