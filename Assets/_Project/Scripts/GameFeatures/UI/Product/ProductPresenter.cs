using System;
using _Project.GameFeatures.MoneySystem;
using _Project.GameFeatures.ShopSystem;
using UnityEngine;
using Zenject;

namespace _Project.GameFeatures.UI.Product
{
    public class ProductPresenter : IProductPresenter, IInitializable, IDisposable
    {
        private readonly ProductBuyer _productBuyer;
        private readonly MoneyStorage _moneyStorage;
        private ScriptableObjects.Product _currentProduct;

        private bool _buttonBuyEnabled;

        public ProductPresenter(ProductBuyer productBuyer, ScriptableObjects.Product currentProduct,
            MoneyStorage moneyStorage)
        {
            _productBuyer = productBuyer;
            _currentProduct = currentProduct;
            _moneyStorage = moneyStorage;
        }

        public string Title => _currentProduct ? _currentProduct.Title : string.Empty;
        public Sprite Icon => _currentProduct ? _currentProduct.Icon : null;
        public string Description => _currentProduct ? _currentProduct.Description : string.Empty;
        public string Price => _currentProduct ? _currentProduct.Price.Amount.ToString() : string.Empty;
        public bool IsBuyButtonEnabled => _buttonBuyEnabled;

        public event Action<bool> OnBuyButtonEnabled;
        public event Action OnStateChanged;

        public void Initialize()
        {
            _buttonBuyEnabled = CanBuy();
            _moneyStorage.OnStateChanged += OnMoneyChanged;
        }

        public void Dispose() => 
            _moneyStorage.OnStateChanged -= OnMoneyChanged;

        public void OnBuyClicked()
        {
            if (_currentProduct == null)
                return;

            _productBuyer.Buy(_currentProduct);
        }

        public void ChangeProduct(ScriptableObjects.Product product)
        {
            if (product != _currentProduct)
            {
                _currentProduct = product;
                _buttonBuyEnabled = CanBuy();
                OnStateChanged?.Invoke();
            }
        }

        private void OnMoneyChanged()
        {
            bool canBuy = CanBuy();

            if (canBuy != _buttonBuyEnabled)
            {
                _buttonBuyEnabled = canBuy;
                OnBuyButtonEnabled?.Invoke(IsBuyButtonEnabled);
            }
        }

        private bool CanBuy() => _currentProduct && _productBuyer.CanBuy(_currentProduct);

        public class Factory : PlaceholderFactory<ScriptableObjects.Product, ProductPresenter>
        {
        }
    }
}