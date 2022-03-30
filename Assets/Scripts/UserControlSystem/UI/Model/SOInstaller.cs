using System.ComponentModel;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Utils;
using Zenject;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(SOInstaller), menuName = "Strategy Game/" + nameof(SOInstaller))]
    public class SOInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private AssetsContext _assetsContext;
        [SerializeField] private SelectableValue _selectableValue;
        [SerializeField] private Vector3Value _vector3Value;

        public override void InstallBindings()
        {
            Container.Bind<AssetsContext>().FromInstance(_assetsContext);
            Container.Bind<Vector3Value>().FromInstance(_vector3Value);
            Container.Bind<SelectableValue>().FromInstance(_selectableValue);
        }
    }
}