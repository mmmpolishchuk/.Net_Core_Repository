using System;

namespace DI._FortuneTeller.Repository
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
