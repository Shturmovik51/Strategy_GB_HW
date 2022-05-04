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
        private int healAmount = 15;
        public override async Task ExecuteSpecificCommand(IHealCommand command)
        {
            command.Target.RestoreHealth(healAmount);
            await Task.CompletedTask;
        }  
    }
}