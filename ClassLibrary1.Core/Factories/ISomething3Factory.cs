using ClassLibrary1.Core.Model;

namespace ClassLibrary1.Core
{
    public interface ISomething3Factory
    {
        Something3 Create();
        Something3 Create(string fullName);
    }
}