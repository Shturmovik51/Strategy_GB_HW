using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Utils;
using Zenject;

namespace UserControlSystem.CommandsRealization
{
    public class ProduceGrenadierCommand : IProduceGrenadierCommand
    {
        [Inject(Id = "Grenadier")] public string UnitName { get; }
        [Inject(Id = "Grenadier")] public Sprite Icon { get; }
        [Inject(Id = "Grenadier")] public float ProductionTime { get; }

        public GameObject UnitPrefab => _unitPrefab;
        [InjectAsset("Grenadier")] private GameObject _unitPrefab;

        public GameObject HealthBarsViewGO => _healthBarsView.gameObject;
        [Inject] private HealthBarsView _healthBarsView;
    }
}