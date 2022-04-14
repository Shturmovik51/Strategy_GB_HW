using System;
using UnityEngine;
using UnityEngine.AI;
using Utils;
using UniRx;

namespace Core
{
    public class UnitMovementStop : MonoBehaviour, IAwaitable<AsyncExtensions.Void>
    {
        public event Action OnStop;

        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private CollisionDetector collisionDetector;

        private void Start()
        {
            collisionDetector.Collisions.Subscribe(_ => StopUnit());
        }

        private void Update()
        {
            if (!_agent.pathPending)
            {
                if (_agent.remainingDistance <= _agent.stoppingDistance)
                {
                    if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                    {
                        OnStop?.Invoke();
                    }
                }
            }
        }

        private void StopUnit()
        {
            OnStop?.Invoke();
            _agent.isStopped = true;
            _agent.ResetPath();
        }

        public IAwaiter<AsyncExtensions.Void> GetAwaiter() => new StopAwaiter(this);
    }
}