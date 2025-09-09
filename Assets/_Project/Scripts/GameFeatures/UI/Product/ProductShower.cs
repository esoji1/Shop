using System;

namespace _Project.GameFeatures.UI.Product
{
    public class ProductShower
    {
        private readonly ProductPopup _productPopup;
        private readonly ProductPresenter _productPresenter;

        public ProductShower(ProductPopup productPopup, ProductPresenter productPresenter)
        {
            _productPopup = productPopup;
            _productPresenter = productPresenter;
        }

        public void Show(ScriptableObjects.Product product)
        {
            if (product == null)
                throw new ArgumentNullException();

            _productPresenter.ChangeProduct(product);
            _productPopup.Show();
        }
    }
}