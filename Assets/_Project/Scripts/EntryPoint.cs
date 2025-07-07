using _Project.Scripts.CameraFollower;
using _Project.Scripts.Factories;
using _Project.Scripts.Turret;
using _Project.Scripts.Turret.Controller;
using _Project.Scripts.Turret.Model;
using _Project.Scripts.TurretMovement;
using _Project.Scripts.TurretShootingSystem.Controller;
using UnityEngine;
using Zenject;

namespace _Project.Scripts
{
    public class EntryPoint : IInitializable
    {
        private BaseMonoFactory _turretFactory;
        private IInputable _turretInput;
        private TurretModel _turretModel;
        private TurretGun _turretGun;
        private TurretCameraFollow _turretCameraFollow;
        private TurretShootingController _turretShootingController;

        public EntryPoint(BaseMonoFactory turretFactory,
            IInputable turretInput,
            TurretModel turretModel,
            TurretCameraFollow turretCameraFollow,
            TurretShootingController shootingController,
            TurretGun turretGun)
        {
            _turretFactory = turretFactory;
            _turretInput = turretInput;
            _turretModel = turretModel;
            _turretCameraFollow = turretCameraFollow;
            _turretShootingController = shootingController;
            _turretGun = turretGun;
        }

        public void Initialize()
        {
            var turret = _turretFactory.Create();

            var turretController = turret.GetComponent<TurretMovementController>();
            GetTurretGun(turretController.gameObject, _turretGun);
            turretController.Init(_turretInput, _turretModel, _turretGun.Gun);

            _turretCameraFollow.Init(turret.transform, _turretGun.Gun.transform);

            _turretShootingController.Init(turretController, _turretGun.Gun);
        }

        private void GetTurretGun(GameObject turret, TurretGun gunToInit)
        {
            Transform[] children = turret.GetComponentsInChildren<Transform>();
            
            foreach (Transform child in children)
            {
                if (child.CompareTag("TurretGun"))
                {
                    gunToInit.Init(child.gameObject);
                }
            }
        }
    }
}