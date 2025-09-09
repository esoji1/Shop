using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Product", menuName = "Configs/New Product", order = 0)]
    public class Product : ScriptableObject
    {
        [PreviewField] [SerializeField] private Sprite _icon;
        [SerializeField] private string _title;
        [TextArea] [SerializeField] private string _description;
        [SerializeField] private CurrencyData _price;

        public Sprite Icon => _icon;
        public string Title => _title;
        public string Description => _description;
        public CurrencyData Price => _price;
    }
}