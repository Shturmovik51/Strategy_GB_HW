using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

public sealed class MainUnit : CommandExecutorBase<IAttackCommand>, ISelectable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    private float _health;

    [SerializeField] private Transform _unitsParent;
    [SerializeField] private float _maxHealth;
    [SerializeField] private Sprite _icon;

    private void Start()
    {
        _health = _maxHealth;
    }

    public override void ExecuteSpecificCommand(IAttackCommand command)
        => Debug.Log(command.Action);    
    
}