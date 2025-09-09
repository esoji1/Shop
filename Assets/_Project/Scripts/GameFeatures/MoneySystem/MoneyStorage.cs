using System;
using Sirenix.OdinInspector;

namespace _Project.GameFeatures.MoneySystem
{
    public class MoneyStorage
    {
        [ShowInInspector] public int Money { get; private set; }

        public event Action<int> OnMoneyChanged;
        public event Action<int> OnMoneyAdded;
        public event Action<int> OnMoneyRemoved;
        public event Action OnStateChanged;

        public MoneyStorage(int money)
        {
            if (money < 0)
                throw new ArgumentException($"Money cannot be negative {money}");
            
            Money = money;
        }

        [Button]
        public void SetMoney(int money)
        {
            if (money < 0)
                return;

            Money = money;
            OnMoneyChanged?.Invoke(Money);
            OnStateChanged?.Invoke();
        }

        [Button]
        public bool AddMoney(int money)
        {
            if(money <= 0)
                return false;
            
            Money += money;
            OnMoneyAdded?.Invoke(Money);
            OnStateChanged?.Invoke();
            return true;
        }

        [Button]
        public bool RemoveMoney(int money)
        {
            if(IsEnough(money) == false || money < 0)
                return false;
            
            Money -= money;
            OnMoneyRemoved?.Invoke(Money);
            OnStateChanged?.Invoke();
            return true;
        }
    
        public bool IsEnough(int money) => Money >= money;
    }
}