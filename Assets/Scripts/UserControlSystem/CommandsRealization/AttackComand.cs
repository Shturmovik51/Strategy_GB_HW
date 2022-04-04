using Abstractions.Commands.CommandsInterfaces;

namespace UserControlSystem.CommandsRealization
{
    public class AttackComand : IAttackCommand
    {
        public string Action { get; } = "Атакую";
    }
}