using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandsRealization;
using UnityEngine;
using Zenject;
using System;
using Utils;

namespace UserControlSystem
{
    public class AttackCommandCommandCreator : CommandCreatorBase<IAttackCommand>
    {
        [Inject] private AssetsContext _context;
        private Action<IAttackCommand> _creationCallback;

        [Inject]
        private void Init(GameObjectValue groundClicks) => groundClicks.OnNewValue += ONNewValue;

        private void ONNewValue(GameObject groundClick)
        {
            _creationCallback?.Invoke(_context.Inject(new AttackComand(groundClick)));
            _creationCallback = null;
        }

        protected override void ClassSpecificCommandCreation(Action<IAttackCommand> creationCallback)
            => _creationCallback = creationCallback;

        public override void ProcessCancel()
        {
            base.ProcessCancel();
            _creationCallback = null;
        }
    }
}