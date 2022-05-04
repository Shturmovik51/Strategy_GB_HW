using Abstractions;
using UnityEngine;

namespace Core
{
    public class UnitProductionTask : IUnitProductionTask
    {
        public Sprite Icon { get; }
        public float TimeLeft { get; set; }
        public float ProductionTime { get; }
        public string UnitName { get; }
        public GameObject UnitPrefab { get; }
        public GameObject HealthBarViewGO { get; }

        public UnitProductionTask(float time, Sprite icon, GameObject unitPrefab, string unitName, GameObject healthBarViewGO)
        {
            Icon = icon;
            ProductionTime = time;
            TimeLeft = time;
            UnitPrefab = unitPrefab;
            UnitName = unitName;
            HealthBarViewGO = healthBarViewGO;
        }
    }
}