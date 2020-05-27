using System;

namespace DI._FortuneTeller.Repository
{
    public class FacadeOfFortune : IFortuneFacade
    {
        private IFortuneTeller teller;
        private IFortuneGetter getter;
        public FacadeOfFortune(IFortuneTeller teller, IFortuneGetter getter)
        {
            this.teller = teller;
            this.getter = getter;
        }
        public void TellFortune()
        {
            teller.TellFortune();
        }

        public string GetFortune()
        {
            return getter.GetFortune();
        }

    }
}
