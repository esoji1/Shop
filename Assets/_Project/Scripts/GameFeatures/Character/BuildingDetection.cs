using System;
using _Project.GameFeatures.Input;
using _Project.GameFeatures.ShopSystem;
using UnityEngine;
using Zenject;

namespace _Project.GameFeatures.Character
{
    public class BuildingDetection : IInitializable, IDisposable
    {
        private readonly InputController _inputController;
        private readonly Transform _player;

        public BuildingDetection(InputController inputController, Transform player)
        {
            _inputController = inputController;
            _player = player;
        }

        public void Initialize() => 
            _inputController.OnKeyClickedE += OnKeyClickedE;

        public void Dispose() => 
            _inputController.OnKeyClickedE -= OnKeyClickedE;

        private void OnKeyClickedE()
        {
            float radius = 0.3f;
            Collider2D collider = Physics2D.OverlapCircle(_player.position, radius);

            if (collider != null)
            {
                if (collider.TryGetComponent(out Shop shop))
                    shop.ShowShopView();
            }
        }
    }
}