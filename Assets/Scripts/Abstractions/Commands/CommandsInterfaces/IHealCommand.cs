namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IHealCommand : ICommand
    {
        public IAttackable Target { get; }
    }
}