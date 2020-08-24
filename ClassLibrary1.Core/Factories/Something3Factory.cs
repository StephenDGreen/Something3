using ClassLibrary1.Core.Model;
using System;

namespace ClassLibrary1.Core
{
    public class Something3Factory : ISomething3Factory
    {
        public Something3 Create()
        {
            return new Something3();
        }

        public Something3 Create(string fullName)
        {
            return new Something3()
            {
                FullName = fullName
            };
        }
    }
}