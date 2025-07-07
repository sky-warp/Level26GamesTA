using _Project.Scripts.TurretShootingSystem.Projectiles;
using UnityEngine;

namespace _Project.Scripts.LevelBorders
{
    public class LevelBordersService : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Projectile projectile))
            {
                projectile.SelfPool.Release(projectile);
            }
        }
    }
}