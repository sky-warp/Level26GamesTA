using _Project.Scripts.UI;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Installers
{
    public class MainSceneMonoInstaller : MonoInstaller
    {
        [SerializeField] private UIAnimationsController _uiAnimationsController;

        public override void InstallBindings()
        {
            Container
                .Bind<UIAnimationsController>()
                .FromInstance(_uiAnimationsController)
                .AsSingle();
        }
    }
}