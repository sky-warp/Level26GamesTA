using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.TurretShootingSystem.Projectiles
{
    [RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
    public class BulletProjectile : Projectile
    {
        private float _speed;
        private Rigidbody _rigidbody;
        private Transform _initialPosition;

        private CancellationTokenSource _cts;

        private Vector3 _direction;

        private void OnEnable()
        {
            _cts = new();
        }

        private void Awake()
        {
            _speed = Config.Speed;
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
            SelfPool.Release(this);
        }

        public override void SetSpawnPoint(Vector3 point, Vector3 direction)
        {
            transform.position = point;
            _direction = direction.normalized;
        }

        private void OnDisable()
        {
            _cts?.Cancel();
            _cts?.Dispose();
        }

        private async UniTaskVoid MoveProjectile(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                _rigidbody.linearVelocity = _direction * _speed;

                await UniTask.Yield(PlayerLoopTiming.Update, _cts.Token);
            }
        }
    }
}