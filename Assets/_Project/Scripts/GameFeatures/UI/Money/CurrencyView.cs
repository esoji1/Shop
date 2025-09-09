using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace _Project.GameFeatures.UI.Money
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _currencyText;

        public void SetCurrency(string currency)
        {
            _currencyText.text = currency;
        }

        public void ChangeCurrency(string currency)
        {
            _currencyText.text = currency;
        }
        
        public void AddCurrency(string currency)
        {
            _currencyText.text = currency;
        }

        public void RemoveCurrency(string currency)
        {
            _currencyText.text = currency;
        }
    }
}