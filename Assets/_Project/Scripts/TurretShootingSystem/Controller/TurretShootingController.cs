using _Project.Scripts.Turret;
using _Project.Scripts.Turret.Controller;
using _Project.Scripts.TurretShootingSystem.Projectiles;
using Zenject;

namespace _Project.Scripts.TurretShootingSystem.Controller
{
    public class TurretShootingController : ITickable
    {
        private TurretMovementController _controller;
        private TurretGun _turretGun;
        BaseObjectPool<Projectile> _projectilePool;

        public TurretShootingController(BaseObjectPool<Projectile> projectilePool)
        {
            _projectilePool = projectilePool;
        }

        public void Init(TurretMovementController controller, TurretGun turretGun)
        {
            _controller = controller;
            _turretGun = turretGun;
        }

        public void Tick()
        {
            if (_controller.IsTouched)
            {
                var obj = _projectilePool.Create();
                
                obj.SetSpawnPoint(_turretGun.transform.position, _turretGun.transform.forward);
                
                _projectilePool.OnGet(obj);
            }
        }
    }
}