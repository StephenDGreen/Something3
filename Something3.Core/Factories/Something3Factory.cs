using Something3.Core.Model;
using System;

namespace Something3.Core
{
    public class Something3Factory : ISomething3Factory
    {
        public Model.Something3 Create()
        {
            return new Model.Something3();
        }

        public Model.Something3 Create(string fullName)
        {
            return new Model.Something3()
            {
                FullName = fullName
            };
        }
    }
}