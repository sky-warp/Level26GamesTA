using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.TurretShootingSystem.Projectiles
{
    [RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
    public class BulletProjectile : Projectile
    {
        private Rigidbody _rigidbody;
        private Transform _initialPosition;
        private Quaternion _initialRotation;

        private CancellationTokenSource _cts;

        private Vector3 _direction;

        private void OnEnable()
        {
            _cts = new();
        }

        private void Awake()
        {
            Speed = Config.Speed;
            Damage = Config.Damage;
            _rigidbody = GetComponent<Rigidbody>();
        }

        public override void Move()
        {
            MoveProjectile(_cts.Token).Forget();
        }

        public override void Stop()
        {
            _cts.Cancel();
            _rigidbody.linearVelocity = Vector3.zero;
        }

        public override void SetSpawnPoint(Vector3 point, Vector3 direction, Quaternion rotation)
        {
            transform.position = point;
            _direction = direction;
            _initialRotation = rotation;
        }

        private void OnDestroy()
        {
            _cts.Cancel();
            _cts?.Dispose();
        }

        private async UniTaskVoid MoveProjectile(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                _rigidbody.MoveRotation(_initialRotation.normalized);

                _rigidbody.linearVelocity = _direction * Speed;

                if (_direction != Vector3.zero)
                {
                    _rigidbody.MoveRotation(Quaternion.LookRotation(_direction));
                }

                await UniTask.Yield(PlayerLoopTiming.Update, _cts.Token);
            }
        }
    }
}