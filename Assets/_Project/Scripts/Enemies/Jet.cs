using _Project.Scripts.TurretShootingSystem.Projectiles;
using UnityEngine;

namespace _Project.Scripts.Enemies
{
    public class Jet : Enemy
    {
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
            Destroy(gameObject);
        }

        public override void TakeDamage(Projectile projectile)
        {
            if (Health - projectile.Damage >= 0)
                Health -= projectile.Damage;

            if (Health == 0)
            {
                IsDestroyed = true;
                Destroy(transform.root.gameObject);
            }

            Debug.Log(Health);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Projectile projectile))
                OnHit?.Invoke(projectile);
        }
    }
}