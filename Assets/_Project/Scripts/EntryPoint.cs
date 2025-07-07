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
        private TurretComponents _turretComponents;
        private TurretCameraFollow _turretCameraFollow;
        private TurretShootingController _turretShootingController;

        public EntryPoint(BaseMonoFactory turretFactory,
            IInputable turretInput,
            TurretModel turretModel,
            TurretCameraFollow turretCameraFollow,
            TurretShootingController shootingController,
            TurretComponents turretComponents)
        {
            _turretFactory = turretFactory;
            _turretInput = turretInput;
            _turretModel = turretModel;
            _turretCameraFollow = turretCameraFollow;
            _turretShootingController = shootingController;
            _turretComponents = turretComponents;
        }

        public void Initialize()
        {
            var turret = _turretFactory.Create();

            var turretController = turret.GetComponent<TurretMovementController>();
            GetTurretComponents(turretController.gameObject, _turretComponents);
            turretController.Init(_turretInput, _turretModel, _turretComponents.TopsideBase);

            _turretCameraFollow.Init(turret.transform, _turretComponents.Gun.transform);

            _turretShootingController.Init(turretController, _turretComponents.Gun);
        }

        private void GetTurretComponents(GameObject turret, TurretComponents componentsToInit)
        {
            GameObject turretTopside = new();
            GameObject turretGun = new();
            
            Transform[] children = turret.GetComponentsInChildren<Transform>();
            
            foreach (Transform child in children)
            {
                if (child.CompareTag("TurretGun"))
                {
                    turretGun = child.gameObject;
                }
                if (child.CompareTag("TurretTopside"))
                {
                    turretTopside = child.gameObject;
                }
                
            }
            
            componentsToInit.Init(turretGun, turretTopside);
        }
    }
}