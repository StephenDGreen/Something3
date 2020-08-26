using Something3.Core.Model;

namespace Something3.Core
{
    public interface ISomething3Factory
    {
        Model.Something3 Create();
        Model.Something3 Create(string fullName);
    }
}