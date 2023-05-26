using FolkVillage.Items;
using System.Collections.Generic;
using UnityEngine;

namespace FolkVillage.Player
{
    public delegate void VoidCallback();
    public class InventoryComponent : MonoBehaviour
    {
        [SerializeField]
        private int _capacity;
        [SerializeField]
        private List<Item> _items;

        public event VoidCallback OnInventoryUpdate;

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

            // If the item is stackable, search for an item with the same name
            if (item.IsStackable())
            {
                foreach (var __item in _items)
                {
                    if (__item.GetName() == item.GetName())
                    {
                        var __oldQuantity = __item.GetQuantity();
                        __item.SetQuantity(__oldQuantity + item.GetQuantity());
                        OnInventoryUpdate?.Invoke();
                        return true;
                    }
                }
            }
            _items.Add(item);
            OnInventoryUpdate?.Invoke();
            return true;
        }

        public bool RemoveItem(int index, int quantity = 0)
        {
            if (_items.Count > index)
            {
                if (quantity != 0)
                {
                    var __item = _items[index];
                    var __oldQuantity = __item.GetQuantity();

                    // Player does not have enough quantity of that item
                    if (__oldQuantity < quantity)
                        return false;
                    else
                    {
                        var __newQuantity = __oldQuantity - quantity;
                        if (__newQuantity == 0)
                        {
                            _items.RemoveAt(index);
                        }
                        else
                        {
                            __item.SetQuantity(__newQuantity);
                        }
                        OnInventoryUpdate?.Invoke();
                        return true;
                    }
                }
                else
                {
                    _items.RemoveAt(index);
                    return true;
                }
            }
            return false;
        }

        public bool RemoveItem (Equipment equipment)
        {
            for (var __i = 0; __i < _items.Count; __i++)
            {
                if (equipment == _items[__i])
                {
                    _items.RemoveAt(__i);
                    OnInventoryUpdate?.Invoke();
                    return true;
                }
            }
            return false;
        }

        public Item GetItem (int index)
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
