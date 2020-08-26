using ClassLibrary1.Core;
using ClassLibrary1.Core.Model;
using System;
using System.Collections.Generic;

namespace ClassLibrary1.Application.Services
{
    public class Something3DisplayInteractor : ISomething3DisplayInteractor
    {
        private readonly IClassLibraryPersistence persistence;

        public Something3DisplayInteractor(IClassLibraryPersistence persistence)
        {
            this.persistence = persistence;
        }

        public List<Something3> GetSomething3List()
        {
            return persistence.GetSomething3List();
        }
    }
}
