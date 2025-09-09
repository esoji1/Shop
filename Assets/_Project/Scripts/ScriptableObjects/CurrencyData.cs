using System;
using _Project.GameFeatures.MoneySystem;

namespace _Project.ScriptableObjects
{
    [Serializable]
    public class CurrencyData
    {
        public CurrencyType Type;
        public int Amount;
    }
}