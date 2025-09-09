using _Project.GameFeatures.ShopSystem;
using _Project.GameFeatures.UI.Money;
using _Project.GameFeatures.UI.Product;
using _Project.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace _Project.Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private ProductListView _productListView;
        [SerializeField] private Product[] _products;
        [SerializeField] private CurrencyView _currencyView;
        [SerializeField] private Shop _shop;

        public override void InstallBindings()
        {
            BindMoneyPresenter();
            BindProductListPresenter();
        }

        private void BindMoneyPresenter()
        {
            Container
                .BindInterfacesAndSelfTo<MoneyPresenter>()
                .AsSingle()
                .WithArguments(_currencyView)
                .NonLazy();
        }

        private void BindProductListPresenter()
        {
            Container
                .Bind<Shop>()
                .FromInstance(_shop)
                .AsSingle();

            Container
                .Bind<ProductListView>()
                .FromInstance(_productListView)
                .AsSingle();

            Container
                .Bind<Product>()
                .FromMethodMultiple(_ => _products)
                .AsCached();

            Container
                .BindFactory<Product, ProductPresenter, ProductPresenter.Factory>()
                .AsSingle();

            Container
                .BindInterfacesTo<ProductListPresenter>()
                .AsSingle();
        }
    }
}