using DI._FortuneTeller.Repository;
using Unity;

namespace DI._FortuneTeller
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IFortuneLoader, LoadFortuneClass>();
            container.RegisterType<IFortuneFacade, FacadeOfFortune>();
            container.RegisterType<IFortuneGetter, GetFortuneClass>();
            container.RegisterType<IFortuneTeller, TellFortuneClass>();

            var getFortune = container.Resolve<IFortuneFacade>();
            getFortune.TellFortune();
        }
    }
}
