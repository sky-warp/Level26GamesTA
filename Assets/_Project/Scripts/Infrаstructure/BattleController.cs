using _Project.Scripts.Enemies;
using _Project.Scripts.TurretShootingSystem.Projectiles;

namespace _Project.Scripts.Infrаstructure
{
    public class BattleController
    {
        private Enemy _currentEnemy;

        public void SetCurrentEnemy(Enemy enemy)
        {
            _currentEnemy = enemy;
            _currentEnemy.OnHit += TakeDamageFromProjectile;
        }

        public void ResetCurrentEnemy()
        {
            _currentEnemy.OnHit -= TakeDamageFromProjectile;
            _currentEnemy = null;
        }
        
        private void TakeDamageFromProjectile(Projectile projectile)
        {
            _currentEnemy.TakeDamage(projectile);
        }
    }
}