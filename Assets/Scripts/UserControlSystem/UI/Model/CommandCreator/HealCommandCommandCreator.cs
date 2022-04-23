using Abstractions.Commands.CommandsInterfaces;

namespace UserControlSystem
{
    public sealed class HealCommandCommandCreator : CancellableCommandCreatorBase<IHealCommand, IAttackable>
    {
        protected override IHealCommand CreateCommand(IAttackable argument) => new HealCommand(argument);
    }
}