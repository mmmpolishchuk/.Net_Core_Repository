using System;
using System.Collections.Generic;
using System.Text;

namespace Dependency_Injection_Project.Repository
{
    public class LoadFortuneClass : IFortuneLoader
    {
        public string LoadFortune()
        {
            return "You will get a coronavirus disease.";
        }
    }
}
