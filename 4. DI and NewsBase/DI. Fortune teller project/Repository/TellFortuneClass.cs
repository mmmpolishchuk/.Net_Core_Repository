using System;
using System.Collections.Generic;
using System.Text;

namespace Dependency_Injection_Project.Repository
{
    public class TellFortuneClass : IFortuneTeller
    {
        private IFortuneLoader loader;

        public TellFortuneClass(IFortuneLoader loader)
        {
            this.loader = loader;
        }
        public void TellFortune()
        {
            Console.WriteLine(loader.LoadFortune());
        }
    }
}
