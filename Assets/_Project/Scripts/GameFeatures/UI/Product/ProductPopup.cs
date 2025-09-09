using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.GameFeatures.UI.Product
{
    public class ProductPopup : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private TMP_Text _price;
        [SerializeField] private Button _buyButton;

        private IProductPresenter _productPresenter;

        [Inject]
        public void Construct(IProductPresenter productPresenter) => 
            _productPresenter = productPresenter;

        [Button]
        public void Show()
        {
            OnStateChanged();
            
            _buyButton.onClick.AddListener(_productPresenter.OnBuyClicked);
            _productPresenter.OnBuyButtonEnabled += OnBuyButtonEnabled;
            _productPresenter.OnStateChanged += OnStateChanged;

            gameObject.SetActive(true);
        }

        [Button]
        public void Hide()
        {
            _buyButton.onClick.RemoveListener(_productPresenter.OnBuyClicked);
            _productPresenter.OnBuyButtonEnabled -= OnBuyButtonEnabled;
            _productPresenter.OnStateChanged -= OnStateChanged;

            gameObject.SetActive(false);
        }

        private void OnBuyButtonEnabled(bool enabled) => _buyButton.interactable = enabled;
        
        private void OnStateChanged()
        {
            _title.text = _productPresenter.Title;
            _icon.sprite = _productPresenter.Icon;
            _description.text = _productPresenter.Description;
            _price.text = _productPresenter.Price;
            _buyButton.interactable = _productPresenter.IsBuyButtonEnabled;
        }
    }
}