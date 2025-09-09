using System;
using _Project.GameFeatures.MoneySystem;
using Zenject;

namespace _Project.GameFeatures.UI.Money
{
    public class MoneyPresenter : IInitializable, IDisposable
    {
        private readonly MoneyStorage _moneyStorage;
        private readonly CurrencyView _currencyView;

        public MoneyPresenter(MoneyStorage moneyStorage, CurrencyView currencyView)
        {
            _moneyStorage = moneyStorage;
            _currencyView = currencyView;
        }

        public void Initialize()
        {
            _currencyView.SetCurrency(_moneyStorage.Money.ToString());

            _moneyStorage.OnMoneyChanged += OnMoneyChanged;
            _moneyStorage.OnMoneyAdded += OnMoneyAdded;
            _moneyStorage.OnMoneyRemoved += OnMoneyRemoved;
        }

        public void Dispose()
        {
            _moneyStorage.OnMoneyChanged -= OnMoneyChanged;
            _moneyStorage.OnMoneyAdded -= OnMoneyAdded;
            _moneyStorage.OnMoneyRemoved -= OnMoneyRemoved;
        }

        private void OnMoneyChanged(int money)
        {
            _currencyView.ChangeCurrency(money.ToString());
        }

        private void OnMoneyAdded(int money)
        {
            _currencyView.AddCurrency(money.ToString());
        }

        private void OnMoneyRemoved(int money)
        {
            _currencyView.RemoveCurrency(money.ToString());
        }
    }
}