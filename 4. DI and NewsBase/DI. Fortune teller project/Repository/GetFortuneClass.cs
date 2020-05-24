using System;
using System.Collections.Generic;
using System.Text;

namespace Dependency_Injection_Project.Repository
{
    public class GetFortuneClass : IFortuneGetter
    {
        private IFortuneLoader loader;

        public GetFortuneClass(IFortuneLoader loader)
        {
            this.loader = loader;
        }
        public string GetFortune()
        {
            return loader.LoadFortune();
        }
    }
}
