using FolkVillage.Player;
using System.Collections.Generic;
using UnityEngine;

namespace FolkVillage.Items
{
    public class ContainerComponent : MonoBehaviour
    {
        [SerializeField]
        protected int _capacity;
        [SerializeField]
        protected List<Item> _items;

        public event VoidCallback OnContainerUpdate;

        public List<Item> GetItems()
        {
            return _items;
        }

        public bool AddItem(Item item)
        {
            if (_items.Count == _capacity)
            {
                return false;
            }
            
            _items.Add(item);
            OnContainerUpdate?.Invoke();
            return true;
        }

        public bool RemoveItem(int index)
        {
            if (_items.Count > index)
            {
                _items.RemoveAt(index);
                OnContainerUpdate?.Invoke();
                return true;
            }
            return false;
        }

        public bool RemoveItem(Item item)
        {
            for (var __i = 0; __i < _items.Count; __i++)
            {
                if (item == _items[__i])
                {
                    _items.RemoveAt(__i);
                    OnContainerUpdate?.Invoke();
                    return true;
                }
            }
            return false;
        }

        public Item GetItem(int index)
        {
            if (index >= _items.Count)
            {
                return null;
            }
            else
            {
                return _items[index];
            }
        }
    }
}


