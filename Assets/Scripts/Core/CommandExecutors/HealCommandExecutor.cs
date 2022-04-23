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
    public class HealCommandExecutor : CommandExecutorBase<IHealCommand>
    {                
        public override async Task ExecuteSpecificCommand(IHealCommand command)
        {
            Debug.Log(2);
            //_targetTransform = (command.Target as Component).transform;
            //_currentAttackOp = new AttackOperation(this, command.Target);
            //Update();
            //_stopCommandExecutor.CancellationTokenSource = new CancellationTokenSource();
            //try
            //{
            //    await _currentAttackOp.WithCancellation(_stopCommandExecutor.CancellationTokenSource.Token);
            //}
            //catch
            //{
            //    _currentAttackOp.Cancel();
            //}
            //_animator.SetTrigger("Idle");
            //_currentAttackOp = null;
            //_targetTransform = null;
            //_stopCommandExecutor.CancellationTokenSource = null;
        }  
    }
}