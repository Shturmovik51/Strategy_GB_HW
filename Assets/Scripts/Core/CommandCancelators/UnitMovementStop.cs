using System;
using UnityEngine;
using UnityEngine.AI;
using Utils;

namespace Core
{
    public class UnitMovementStop : MonoBehaviour, IAwaitable<AsyncExtensions.Void>
    {  
        [SerializeField] private NavMeshAgent _agent;
        public Action<AsyncExtensions.Void> OnNewValue { get; set; }

        private void Update()
        {
            if (!_agent.pathPending)
            {
                if (_agent.remainingDistance <= _agent.stoppingDistance)
                {
                    if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                    {
                        OnNewValue?.Invoke(new AsyncExtensions.Void());
                    }
                }
            }
        }

        public IAwaiter<AsyncExtensions.Void> GetAwaiter() 
        { 
            return new StopAwaiter(this); 
        }
    }
}