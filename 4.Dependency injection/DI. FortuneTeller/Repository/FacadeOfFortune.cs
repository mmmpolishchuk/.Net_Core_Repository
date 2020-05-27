using System;

namespace DI._FortuneTeller.Repository
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
