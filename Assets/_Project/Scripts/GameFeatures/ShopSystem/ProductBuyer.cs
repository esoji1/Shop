using System;
using _Project.GameFeatures.MoneySystem;
using _Project.ScriptableObjects;
using Sirenix.OdinInspector;

namespace _Project.GameFeatures.ShopSystem
{
    public class ProductBuyer
    {
        public event Action<Product> OnProductBought;

        private readonly MoneyStorage _currencyMoneyStorage;

        public ProductBuyer(MoneyStorage moneyStorage) => _currencyMoneyStorage = moneyStorage;

        [Button]
        public bool CanBuy(Product product)
        {
            return product == null
                ? throw new ArgumentNullException(nameof(product))
                : _currencyMoneyStorage.IsEnough(product.Price.Amount);
        }

        [Button]
        public bool Buy(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (_currencyMoneyStorage.IsEnough(product.Price.Amount) == false)
            {
                UnityEngine.Debug.LogWarning($"<color=red>Not enough money for product {product.Title}!</color>");
                return false;
            }

            _currencyMoneyStorage.RemoveMoney(product.Price.Amount);
            OnProductBought?.Invoke(product);

            UnityEngine.Debug.Log($"<color=green>Product {product.Title} successfully purchased!</color>");
            return true;
        }
    }
}