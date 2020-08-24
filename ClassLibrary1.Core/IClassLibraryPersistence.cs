using ClassLibrary1.Core.Model;
using System.Collections.Generic;

namespace ClassLibrary1.Core
{
    public interface IClassLibraryPersistence
    {
        void SaveSomething3(Something3 something3);
        List<Something3> GetSomething3List();
    }
}