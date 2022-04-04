namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IStopCommand : ICommand
    {
        public string Action { get; }
    }
}