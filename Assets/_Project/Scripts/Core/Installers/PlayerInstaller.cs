using _Project.GameFeatures.Character;
using _Project.GameFeatures.Input;
using UnityEngine;
using Zenject;

namespace _Project.Core.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Player _player;
        
        public override void InstallBindings()
        {
            BindMove();
            BindBuildingDetection();
        }

        private void BindMove()
        {
            Container
                .BindInterfacesAndSelfTo<InputController>()
                .AsSingle();

            Container
                .Bind<Movement>()
                .AsSingle()
                .WithArguments(_player.transform);
        }

        private void BindBuildingDetection()
        {
            Container
                .BindInterfacesAndSelfTo<BuildingDetection>()
                .AsSingle()
                .WithArguments(_player.transform);
        }
    }
}