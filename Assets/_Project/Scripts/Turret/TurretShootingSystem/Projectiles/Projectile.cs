using _Project.Scripts.Configs;
using UnityEngine;
using UnityEngine.Pool;

namespace _Project.Scripts.TurretShootingSystem.Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] protected ProjectileConfig Config;
        
        public abstract void Move();
        public abstract void Stop();
        public abstract void SetSpawnPoint(Vector3 point, Vector3 direction, Quaternion rotation);
        public IObjectPool<Projectile> SelfPool;
    }
}