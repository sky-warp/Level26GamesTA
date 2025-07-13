using _Project.Scripts.Controller;
using _Project.Scripts.Turret.Model;
using _Project.Scripts.TurretShootingSystem.Projectiles;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.TurretShootingSystem.Controller
{
    public class TurretShootingController : ITickable
    {
        private TurretMovementController _controller;
        private GameObject _turretGun;
        private BaseObjectPool<Projectile> _projectilePool;

        private float _shootingInterval;
        private bool _isReadyForShoot = true;
        
        public TurretShootingController(BaseObjectPool<Projectile> projectilePool, TurretModel model)
        {
            _projectilePool = projectilePool;
            _shootingInterval = model.ShootInterval;
        }

        public void Init(TurretMovementController controller, GameObject turretGun)
        {
            _controller = controller;
            _turretGun = turretGun;
        }

        public async void Tick()
        {
            if (_controller.IsTouched && _isReadyForShoot)
            {
                var obj = _projectilePool.Pool.Get();

                if (obj == null)
                {
                    obj = _projectilePool.Create();
                }
                
                obj.SetSpawnPoint(_turretGun.transform.position, _turretGun.transform.forward,
                    _turretGun.transform.localRotation);

                _projectilePool.OnGet(obj);
                
                _isReadyForShoot = false;

                await ResetShootingAbility();
            }
        }

        private async UniTask ResetShootingAbility()
        {
            await UniTask.WaitForSeconds(_shootingInterval);
            
            _isReadyForShoot = true;
        }
    }
}