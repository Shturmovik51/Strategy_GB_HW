using System;
using UniRx;
using UnityEngine;
using UnityEngine.AI;

namespace Core
{
    public class CollisionDetector : MonoBehaviour
    {
        [SerializeField] private float _collisionTimeBeforeStop;
        [SerializeField] private NavMeshAgent _agent;
        private float currentValue;
        public Subject<float> Collisions => _collisions;
        private Subject<float> _collisions = new Subject<float>();

        private void OnTriggerStay(Collider other)                 
        {
            if (other.TryGetComponent(out NavMeshAgent unit))
            {
                if (_agent.velocity != Vector3.zero)
                {
                    currentValue -= Time.deltaTime;
                    if(currentValue <= 0)
                    {
                        _collisions.OnNext(currentValue);
                        currentValue = _collisionTimeBeforeStop;
                    }
                }
                else
                    currentValue = _collisionTimeBeforeStop;
            }
        }
        private void OnTriggerExit(Collider other)        
        {
            currentValue = _collisionTimeBeforeStop;
        }
    }
}
