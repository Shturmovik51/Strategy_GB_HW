using Abstractions;
using Zenject;

namespace Assets.Scripts.Abstractions
{
    public class ChomperInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IHealthHolder>().WithId("Chomper").FromComponentInChildren();
            Container.Bind<float>().WithId("ChomperAttackDistance").FromInstance(5f);
            Container.Bind<int>().WithId("ChomperAttackPeriod").FromInstance(1400);
        }
    }
}