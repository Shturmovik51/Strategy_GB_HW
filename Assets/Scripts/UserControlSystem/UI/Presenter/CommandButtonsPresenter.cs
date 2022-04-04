using System;
using System.Collections.Generic;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem.CommandsRealization;
using UserControlSystem.UI.View;
using Utils;

namespace UserControlSystem.UI.Presenter
{
    public sealed class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _view;
        [SerializeField] private AssetsContext _context;

        private ISelectable _currentSelectable;

        private void Start()
        {
            _selectable.OnSelected += ONSelected;
            ONSelected(_selectable.CurrentValue);

            _view.OnClick += ONButtonClick;
        }

        private void ONSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }
            _currentSelectable = selectable;

            _view.Clear();

            if (selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
                _view.MakeLayout(commandExecutors);
            }
        }

        private void ONButtonClick(ICommandExecutor commandExecutor)
        {
            if (commandExecutor is CommandExecutorBase<IAttackCommand> AttackProducer)
            {
                AttackProducer.ExecuteSpecificCommand(_context.Inject(new AttackComand()));
                return;
            }
            else if (commandExecutor is CommandExecutorBase<IPatrolCommand> PatrolProducer)
            {
                PatrolProducer.ExecuteSpecificCommand(_context.Inject(new PatrolCommand()));
                return;
            }
            else if (commandExecutor is CommandExecutorBase<IStopCommand> StopProducer)
            {
                StopProducer.ExecuteSpecificCommand(_context.Inject(new StopCommand()));
                return;
            }
            else if (commandExecutor is CommandExecutorBase<IProduceUnitCommand> UnitProducer)
            {
                UnitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommandHeir()));
                return;
            }
            else
            {
                throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(ONButtonClick)}: " +
                                               $"Unknown type of commands executor: {commandExecutor.GetType().FullName}!");
            }
        }
    }
}