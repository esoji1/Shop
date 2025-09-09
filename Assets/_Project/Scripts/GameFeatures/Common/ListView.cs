using System.Collections.Generic;
using UnityEngine;

namespace _Project.GameFeatures.Common
{
    public class ListView<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private T _itemPrefab;
        [SerializeField] private Transform _container;

        private readonly List<T> _items = new();
        private readonly Queue<T> _freeList = new();

        public T SpawnElement()
        {
            if (_freeList.TryDequeue(out var item))
            {
                item.gameObject.SetActive(true);
            }
            else
            {
                item = Instantiate(_itemPrefab, _container);
            }

            _items.Add(item);
            return item;
        }

        public void DespawnElement(T item)
        {
            if (item != null && _items.Remove(item))
            {
                item.gameObject.SetActive(false);
                _freeList.Enqueue(item);
            }
        }

        public void Clear()
        {
            for (int i = 0, count = _items.Count; i < count; i++)
            {
                T item = _items[i];
                item.gameObject.SetActive(false);
                _freeList.Enqueue(item);
            }

            _items.Clear();
        }
    }
}