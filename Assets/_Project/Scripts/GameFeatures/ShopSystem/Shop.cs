using System;
using _Project.GameFeatures.UI;
using UnityEngine;

namespace _Project.GameFeatures.ShopSystem
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private ShopPopup _shopPopup;

        public event Action OnOpenShop;

        public void ShowShopView()
        {
            _shopPopup.Show();
            OnOpenShop?.Invoke();
        }
    }
}