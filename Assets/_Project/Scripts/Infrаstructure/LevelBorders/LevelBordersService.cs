using _Project.Scripts.Enemies;
using _Project.Scripts.TurretShootingSystem.Projectiles;
using UnityEngine;

namespace _Project.Scripts.Infrаstructure.LevelBorders
{
    public class LevelBordersService : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Projectile projectile))
                projectile.SelfPool.Release(projectile);

            if (other.CompareTag("JetEnemy"))
                other.transform.root.GetComponent<Jet>().DestroyEnemy();
        }
    }
}