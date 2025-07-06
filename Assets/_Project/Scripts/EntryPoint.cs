using _Project.Scripts.CameraFollower;
using _Project.Scripts.Factories;
using _Project.Scripts.Turret.Model;
using _Project.Scripts.TurretMovement;
using Zenject;

namespace _Project.Scripts
{
    public class EntryPoint : IInitializable
    {
        private BaseMonoFactory _turretFactory;
        private IInputable _turretInput;
        private TurretModel _turretModel;
        private TurretCameraFollow _turretCameraFollow;

        public EntryPoint(BaseMonoFactory turretFactory,
            IInputable turretInput,
            TurretModel turretModel,
            TurretCameraFollow turretCameraFollow)
        {
            _turretFactory = turretFactory;
            _turretInput = turretInput;
            _turretModel = turretModel;
            _turretCameraFollow = turretCameraFollow;
        }

        public void Initialize()
        {
            var turret = _turretFactory.Create();

            var turretController = turret.GetComponent<TurretMovementController>();
            turretController.Init(_turretInput, _turretModel);
            
            _turretCameraFollow.Init(turret.transform);
        }
    }
}