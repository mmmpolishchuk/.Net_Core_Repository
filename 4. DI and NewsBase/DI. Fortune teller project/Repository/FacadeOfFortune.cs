using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Dependency_Injection_Project.Repository
{
    public class FacadeOfFortune : IFortuneFacade
    {
        IFortuneLoader loader = new LoadFortuneClass();
        public void TellFortune()
        {
            Console.WriteLine(loader.LoadFortune());
        }

        public string GetFortune()
        {
            return loader.LoadFortune();
        }

    }
}
