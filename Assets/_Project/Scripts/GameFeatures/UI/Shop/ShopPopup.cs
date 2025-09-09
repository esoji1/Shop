using UnityEngine;

namespace _Project.GameFeatures.UI
{
    public class ShopPopup : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}