using Something3.Core.ViewModel;
using System.Collections.Generic;

namespace Something3.Core.Services
{
    public interface IClassLibraryPersistence
    {
        void SaveSomething3(Model.Something3 something3);
        List<Model.Something3> GetSomething3List();
        List<Something3WithId> GetSomething3WithIdList();
    }
}