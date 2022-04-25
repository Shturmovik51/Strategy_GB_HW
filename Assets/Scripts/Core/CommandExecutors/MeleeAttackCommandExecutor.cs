using System;
using System.Threading;
using System.Threading.Tasks;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using Assets.Scripts.Abstractions;
using UniRx;
using UnityEngine;
using UnityEngine.AI;
using Utils;
using Zenject;

namespace Core.CommandExecutors
{
    public class MeleeAttackCommandExecutor : AttackCommandExecutorBase
    {
        [Inject(Id = "Chomper")] private IHealthHolder _ourHealth;
        [Inject(Id = "ChomperAttackDistance")] private float _attackingDistance;
        [Inject(Id = "ChomperAttackPeriod")] private int _attackingPeriod;

        [Inject]
        private void SetUnitParameters()
        {
            OurHealth = _ourHealth;
            AttackingDistance = _attackingDistance;
            AttackingPeriod = _attackingPeriod;
        }
    }
}