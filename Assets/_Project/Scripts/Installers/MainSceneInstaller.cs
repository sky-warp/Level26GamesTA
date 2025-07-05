using _Project.Scripts.Configs;
using _Project.Scripts.Factories;
using _Project.Scripts.Turret.Model;
using _Project.Scripts.TurretMovement;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Installers
{
    [CreateAssetMenu(fileName = "MainInstaller", menuName = "Installers/Main Scene Installer")]
    public class MainSceneInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private TurretConfig _turretConfig;
        
        [SerializeField] private GameObject _turretPrefab;

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
        }
    }
}