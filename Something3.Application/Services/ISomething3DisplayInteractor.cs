using Something3.Core.Model;
using System.Collections.Generic;

namespace Something3.Application.Services
{
    public interface ISomething3DisplayInteractor
    {
        List<Core.Model.Something3> GetSomething3List();
    }
}