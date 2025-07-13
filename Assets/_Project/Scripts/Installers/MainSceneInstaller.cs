using _Project.Scripts.Configs;
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
using _Project.Scripts.TurretShootingSystem.Projectiles;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Installers
{
    [CreateAssetMenu(fileName = "MainInstaller", menuName = "Installers/Main Scene Installer")]
    public class MainSceneInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private TurretConfig _turretConfig;
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private ProjectilePoolConfig _projectilePoolConfig;
        [SerializeField] private GameConfig _gameConfig;

        [SerializeField] private VisualEffectsConfig _visualEffectsConfig;

        [SerializeField] private Projectile _bulletPrefab;

        public override void InstallBindings()
        {
            var battleController = new BattleController();
            var gameStateController = new GameStateController();

            Container
                .BindInterfacesTo<EntryPoint>()
                .AsSingle()
                .WithArguments(new TurretFactory(_turretConfig.Prefab));

            Container
                .Bind<IInputable>()
                .To<TouchMovementSystem>()
                .AsSingle();

            Container
                .Bind<TurretModel>()
                .AsSingle()
                .WithArguments(_turretConfig);

            Container
                .Bind<TurretComponents>()
                .AsSingle();

            Container
                .Bind<TurretCameraFollow>()
                .FromInstance(Camera.main.GetComponent<TurretCameraFollow>());

            Container
                .BindInterfacesAndSelfTo<TurretShootingController>()
                .AsSingle()
                .WithArguments(new ProjectilePool(_bulletPrefab, _projectilePoolConfig));

            Container
                .BindInterfacesAndSelfTo<TurretAnimationController>()
                .AsSingle();

            Container
                .Bind<EnemySpawnService>()
                .AsSingle()
                .WithArguments(new EnemyFactory(_enemyConfig,
                        new VisualEffectFactory(_visualEffectsConfig.JetDestroyEffect)), _gameConfig.NumberOfEnemyWaves,
                    battleController, gameStateController);

            Container
                .Bind<CoroutineStarter>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();

            Container
                .Bind<BattleController>()
                .FromInstance(battleController)
                .AsSingle();

            Container
                .Bind<GameStateController>()
                .FromInstance(gameStateController)
                .AsSingle();
        }
    }
}