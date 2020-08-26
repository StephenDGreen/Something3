using Something3.Core.Model;
using System.Collections.Generic;

namespace Something3.Core
{
    public interface IClassLibraryPersistence
    {
        void SaveSomething3(Model.Something3 something3);
        List<Model.Something3> GetSomething3List();
    }
}