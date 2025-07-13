using System;
using _Project.Scripts.Controller;
using _Project.Scripts.Enemies;
using _Project.Scripts.Factories;
using _Project.Scripts.GameStateMachine;
using _Project.Scripts.Infrаstructure;
using _Project.Scripts.Infrаstructure.CameraFollower;
using _Project.Scripts.Turret;
using _Project.Scripts.Turret.Model;
using _Project.Scripts.TurretAnimations;
using _Project.Scripts.TurretMovement;
using _Project.Scripts.TurretShootingSystem.Controller;
using _Project.Scripts.UI;
using UnityEngine;
using Zenject;

namespace _Project.Scripts
{
    public class EntryPoint : IInitializable, IDisposable
    {
        private BaseMonoFactory _turretFactory;
        private IInputable _turretInput;
        private TurretModel _turretModel;
        private TurretComponents _turretComponents;
        private TurretCameraFollow _turretCameraFollow;
        private TurretShootingController _turretShootingController;
        private TurretAnimationController _turretAnimationController;
        private CoroutineStarter _coroutineStarter;
        private EnemySpawnService _spawnService;
        private UIAnimationsController _animationsController;
        private GameStateController _gameStateController;
        private SceneManager _sceneManager;

        public EntryPoint(BaseMonoFactory turretFactory,
            IInputable turretInput,
            TurretModel turretModel,
            TurretCameraFollow turretCameraFollow,
            TurretShootingController shootingController,
            TurretComponents turretComponents,
            TurretAnimationController turretAnimationController,
            CoroutineStarter coroutineStarter,
            EnemySpawnService spawnService,
            UIAnimationsController animationsController,
            GameStateController gameStateController)
        {
            _turretFactory = turretFactory;
            _turretInput = turretInput;
            _turretModel = turretModel;
            _turretCameraFollow = turretCameraFollow;
            _turretShootingController = shootingController;
            _turretComponents = turretComponents;
            _turretAnimationController = turretAnimationController;
            _coroutineStarter = coroutineStarter;
            _spawnService = spawnService;
            _animationsController = animationsController;
            _gameStateController = gameStateController;
        }

        public void Initialize()
        {
            var turret = _turretFactory.Create();

            var turretController = turret.GetComponent<TurretMovementController>();
            GetTurretComponents(turretController.gameObject, _turretComponents);
            turretController.Init(_turretInput, _turretModel, _turretComponents.TopsideBase);
            _gameStateController.OnGameEnd += turretController.TurnOffInput;

            _turretAnimationController.Init(turretController);

            _turretCameraFollow.Init(turret.transform, _turretComponents.Gun.transform);

            _turretShootingController.Init(turretController, _turretComponents.Gun);

            _animationsController.Init();
            _sceneManager = new SceneManager();
            _animationsController.OnContinueButtonPressed += _sceneManager.RestartGame;

            _coroutineStarter.StartSpecificCoroutine(_spawnService.SpawnJetWaves());
        }

        private void GetTurretComponents(GameObject turret, TurretComponents componentsToInit)
        {
            GameObject turretTopside = null;
            GameObject turretGun = null;

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

        public void Dispose()
        {
            _animationsController.OnContinueButtonPressed -= _sceneManager.RestartGame;
        }
    }
}