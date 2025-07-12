using System;
using UnityEngine;

namespace _Project.Scripts.Enemies
{
    public class Jet : Enemy
    {
        public Action OnJetDestroyed;
        
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public override void MoveFlyingEnemy()
        {
            var newDirection = new Vector3(0, -Destination.y, Destination.z).normalized;

            _rigidbody.linearVelocity = newDirection * Speed;
        }

        public override void DestroyEnemy()
        {
            IsDestroyed = true;
            OnJetDestroyed?.Invoke();
            Destroy(gameObject);
        }
    }
}