using FolkVillage.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FolkVillage.UI
{
    public class InventoryUI : UIPanel
    {
        [SerializeField]
        private List<InventorySlotUI> _inventorySlots;

        [SerializeField]
        private List<EquipmentSlotUI> _equipmentSlots;

        private InventoryComponent _inventory;
        private EquipmentComponent _equipment;

        public void Setup(PlayerEntity player)
        {
            
            for (var __i = 0; __i < _inventorySlots.Count; __i++)
            {
                _inventorySlots[__i].Setup(__i);
                _inventorySlots[__i].OnSlotClick += TryEquip;
            }

            for (var __i = 0; __i < _equipmentSlots.Count; __i++)
            {
                _equipmentSlots[__i].Setup(__i);
                _equipmentSlots[__i].OnSlotClick += TryDeEquip;
            }

            _inventory = player.Inventory;
            _equipment = player.Equipment;

            Refresh();

            _inventory.OnContainerUpdate += RefreshInventory;
            _equipment.OnEquipmentUpdate += RefreshEquipment;
        }

        public void Refresh()
        {
            RefreshInventory();
            RefreshEquipment();
        }

        private void RefreshInventory()
        {
            var __inventoryItems = _inventory.GetItems();
            for (var __i = 0; __i < _inventorySlots.Count; __i++)
            {
                if (__i >= __inventoryItems.Count)
                {
                    _inventorySlots[__i].UpdateSlot(null);
                    continue;
                }
                _inventorySlots[__i].UpdateSlot(__inventoryItems[__i]);
            }
        }

        private void RefreshEquipment()
        {
            var __equipmentItems = _equipment.GetEquipmentSlots();
            for (var __i = 0; __i < _equipmentSlots.Count; __i++)
            {
                if (__i >= __equipmentItems.Count)
                {
                    _equipmentSlots[__i].UpdateSlot(null);
                    continue;
                }
                _equipmentSlots[__i].UpdateSlot(__equipmentItems[__i]);
            }
        }

        private void TryEquip(int index)
        {
            if (_equipment.Equip(index))
            {
                Debug.Log("Equipped");
            }
        }

        private void TryDeEquip(int index)
        {
            if (_equipment.DeEquip(index))
            {
                Debug.Log("Deequipped");
            }
        }

        private void OnEnable()
        {
            Refresh();
        }
    }
}

