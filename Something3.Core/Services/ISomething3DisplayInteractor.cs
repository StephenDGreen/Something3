using Something3.Core.ViewModel;
using System.Collections.Generic;

namespace Something3.Core.Services
{
    public interface ISomething3DisplayInteractor
    {
        List<Model.Something3> GetSomething3List();
        List<Something3WithId> GetThings();
    }
}