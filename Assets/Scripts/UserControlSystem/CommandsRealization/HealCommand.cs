using Abstractions.Commands.CommandsInterfaces;

public sealed class HealCommand : IHealCommand
{
    public IAttackable Target { get; }

    public HealCommand(IAttackable target) => Target = target;
}