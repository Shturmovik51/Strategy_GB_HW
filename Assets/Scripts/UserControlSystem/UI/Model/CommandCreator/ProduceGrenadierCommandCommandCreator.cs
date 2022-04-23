using System;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandsRealization;
using Utils;
using Zenject;

namespace UserControlSystem
{
    public sealed class ProduceGrenadierCommandCommandCreator : CommandCreatorBase<IProduceGrenadierCommand>
    {
        [Inject] private AssetsContext _context;
        [Inject] private DiContainer _diContainer;

        protected override void ClassSpecificCommandCreation(Action<IProduceGrenadierCommand> creationCallback)
        {
            var produceGrenadierCommand = _context.Inject(new ProduceGrenadierCommand());
            _diContainer.Inject(produceGrenadierCommand);
            creationCallback?.Invoke(produceGrenadierCommand);
        }
    }
}