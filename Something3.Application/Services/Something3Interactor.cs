using Something3.Core;

namespace Something3.Application.Services
{
    public class Something3Interactor : ISomething3Interactor
    {
        private ISomething3Factory something3Factory;
        private readonly IClassLibraryPersistence persistence;

        public Something3Interactor(ISomething3Factory something3Factory, IClassLibraryPersistence persistence)
        {
            this.something3Factory = something3Factory;
            this.persistence = persistence;
        }

        public void CreateSomething3()
        {
            var something3 = something3Factory.Create();
            persistence.SaveSomething3(something3);
        }

        public void CreateSomething3(string fullName)
        {
            var something3 = something3Factory.Create(fullName);
            persistence.SaveSomething3(something3);
        }
    }
}
