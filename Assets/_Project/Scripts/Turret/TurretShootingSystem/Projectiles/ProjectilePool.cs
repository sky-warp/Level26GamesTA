using _Project.Scripts.Configs;
using UnityEngine;

namespace _Project.Scripts.TurretShootingSystem.Projectiles
{
    public class ProjectilePool : BaseObjectPool<Projectile>
    {
        public ProjectilePool(Projectile prefab, ProjectilePoolConfig config) : base(prefab, config)
        {
        }

        public override Projectile Create()
        {
            var projectile = Object.Instantiate(Prefab, Vector3.zero, Quaternion.identity);
            projectile.gameObject.SetActive(false);
            projectile.SelfPool = Pool;
            return projectile;
        }

        public override void OnGet(Projectile obj)
        {
            obj.gameObject.SetActive(true);
            obj.Move();
        }

        public override void OnRelease(Projectile obj)
        {
            obj.gameObject.SetActive(false);
            obj.Stop();
        }

        public override void OnDestroy(Projectile obj)
        {
            GameObject.Destroy(obj);
        }
    }
}