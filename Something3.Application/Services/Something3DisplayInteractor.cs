using Something3.Core;
using Something3.Core.Model;
using System;
using System.Collections.Generic;

namespace Something3.Application.Services
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
    }
}
