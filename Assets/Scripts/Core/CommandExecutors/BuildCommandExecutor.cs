using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using System.Threading.Tasks;
using UnityEngine;

public sealed class BuildCommandExecutor : CommandExecutorBase<IProduceUnitCommand>
{
    [SerializeField] private Transform _unitsParent;

    public override async Task ExecuteSpecificCommand(IProduceUnitCommand command)
    {  
        Instantiate(command.UnitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
        await Task.CompletedTask;
    }
}