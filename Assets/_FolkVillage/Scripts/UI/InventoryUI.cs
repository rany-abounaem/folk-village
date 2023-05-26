using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FolkVillage.UI
{
    public class InventoryUI : UIPanel
    {
        [SerializeField]
        private Transform _items;

        [SerializeField]
        private Transform _equipment;

        public void Setup()
        {
            var __itemSlots = _items.GetComponentsInChildren<InventorySlotUI>();
            
            for (var __i = 0; __i < __itemSlots.Length; __i++)
            {
                __itemSlots[__i].Setup(__i);
            }
        }
    }
}

