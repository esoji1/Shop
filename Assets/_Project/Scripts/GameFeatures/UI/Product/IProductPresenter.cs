using System;
using UnityEngine;

namespace _Project.GameFeatures.UI.Product
{
    public interface IProductPresenter
    {
        string Title { get; }
        Sprite Icon { get; }
        string Description { get; }
        string Price { get; }
        bool IsBuyButtonEnabled { get; }
        
        event Action<bool> OnBuyButtonEnabled;
        event Action OnStateChanged;
 
        void OnBuyClicked();
    }
}