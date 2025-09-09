using System;
using System.Collections.Generic;
using _Project.GameFeatures.ShopSystem;
using Zenject;

namespace _Project.GameFeatures.UI.Product
{
    public class ProductListPresenter : IInitializable, IDisposable
    {
        private readonly ScriptableObjects.Product[] _products;
        private readonly ProductListView _productListView;
        private readonly ProductPresenter.Factory _presenterFactory;

        private readonly Shop _shop;

        private List<ProductPresenter> _presenters = new();
        private List<ProductShower> _productShowers = new();

        public ProductListPresenter(ScriptableObjects.Product[] products, ProductListView productListView, Shop shop,
            ProductPresenter.Factory presenterFactory)
        {
            _products = products;
            _productListView = productListView;
            _shop = shop;
            _presenterFactory = presenterFactory;
        }

        public void Initialize() => _shop.OnOpenShop += SpawnProductPoput;

        public void Dispose()
        {
            for (int i = 0; i < _products.Length; i++)
            {
                ProductPresenter presenter =  _presenters[i];
                presenter.Dispose();
            }

            _presenters.Clear();
            _productListView.Clear();
            _productShowers.Clear();

            _shop.OnOpenShop -= SpawnProductPoput;
        }

        private void SpawnProductPoput()
        {
            for (int i = 0; i < _products.Length; i++)
            {
                ScriptableObjects.Product product = _products[i];
                ProductPresenter productPresenter = _presenterFactory.Create(product);
                productPresenter.Initialize();
                ProductPopup productPopup = _productListView.SpawnElement();
                productPopup.Construct(productPresenter);
                ProductShower productShower = new ProductShower(productPopup, productPresenter);
                productShower.Show(product);

                _presenters.Add(productPresenter);
                _productShowers.Add(productShower);
            }
        }
    }
}