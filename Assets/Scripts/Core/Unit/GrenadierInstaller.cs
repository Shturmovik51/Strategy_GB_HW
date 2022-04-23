using Abstractions;
using Zenject;

namespace Assets.Scripts.Abstractions
{
    public class GrenadierInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IHealthHolder>().FromComponentInChildren();
            Container.Bind<float>().WithId("AttackDistance").FromInstance(20f);
            Container.Bind<int>().WithId("AttackPeriod").FromInstance(1500);
        }
    }
}