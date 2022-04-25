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
    public class RangeAttackCommandExecutor : AttackCommandExecutorBase
    {        
        [SerializeField] private ParticleSystem _attackEffect;

        [Inject(Id = "Grenadier")] private IHealthHolder _ourHealth;
        [Inject(Id = "GrenadierAttackDistance")] private float _attackingDistance;
        [Inject(Id = "GrenadierAttackPeriod")] private int _attackingPeriod;

        [Inject] 
        private void SetUnitParameters()
        {
            OurHealth = _ourHealth;
            AttackingDistance = _attackingDistance;
            AttackingPeriod = _attackingPeriod;
        } 
                
        public override void StartAttackingTargets(IAttackable target)
        {
            base.StartAttackingTargets(target);
            _attackEffect.Play();
        }
    }
}