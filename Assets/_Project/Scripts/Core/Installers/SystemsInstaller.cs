using _Project.GameFeatures.MoneySystem;
using _Project.GameFeatures.ShopSystem;
using UnityEngine;
using Zenject;

namespace _Project.Core.Installers
{
    public class SystemsInstaller : MonoInstaller
    {
        [SerializeField] private int _money;

        public override void InstallBindings()
        {
            BindMoneyStorage();
            BindProductBuyer();
        }

        private void BindMoneyStorage()
        {
            Container
                .Bind<MoneyStorage>()
                .AsSingle()
                .WithArguments(_money);
        }

        private void BindProductBuyer()
        {
            Container
                .Bind<ProductBuyer>()
                .AsSingle();
        }
    }
}