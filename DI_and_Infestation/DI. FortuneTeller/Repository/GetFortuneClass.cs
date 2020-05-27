namespace DI._FortuneTeller.Repository
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
