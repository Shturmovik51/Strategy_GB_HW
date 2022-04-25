using Abstractions;
using Zenject;

namespace Assets.Scripts.Abstractions
{
    public class GrenadierInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IHealthHolder>().WithId("Grenadier").FromComponentInChildren();
            Container.Bind<float>().WithId("GrenadierAttackDistance").FromInstance(20f);
            Container.Bind<int>().WithId("GrenadierAttackPeriod").FromInstance(1500);
        }
    }
}