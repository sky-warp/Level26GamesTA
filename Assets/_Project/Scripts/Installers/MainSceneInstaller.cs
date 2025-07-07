using _Project.Scripts.CameraFollower;
using _Project.Scripts.Configs;
using _Project.Scripts.Factories;
using _Project.Scripts.Turret;
using _Project.Scripts.Turret.Model;
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

        [SerializeField] private GameObject _turretPrefab;

        [SerializeField] private Projectile _bulletPrefab;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<EntryPoint>()
                .AsSingle()
                .WithArguments(new TurretFactory(_turretPrefab));

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
                .WithArguments(new ProjectilePool(_bulletPrefab));
        }
    }
}