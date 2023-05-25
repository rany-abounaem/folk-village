using FolkVillage.Items;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentSlot { Body = 0, Hat = 1 };

namespace FolkVillage.Player
{
    public class EquipmentComponent : MonoBehaviour
    {
        private List<Equipment> _equipment = new List<Equipment>();

        private InventoryComponent _inventory;

        public void Setup (InventoryComponent inventory)
        {
            _inventory = inventory;
        }

        public bool Equip (Equipment equipment)
        {
            if (_inventory.RemoveItem(equipment))
            {
                var __slot = equipment.GetSlot();
                var __slotIndex = (int)__slot;
                if (_equipment[__slotIndex] != null)
                {
                    DeEquip(__slot);
                }
                _equipment[__slotIndex] = equipment;
                return true;
            }
            return false;
            
        }

        public bool DeEquip (EquipmentSlot slot)
        {
            var __slotIndex = (int)slot;
            if (_inventory.AddItem(_equipment[__slotIndex]))
            {
                _equipment[__slotIndex] = null;
                return true;
            }
            return false;
        }

        public List<Equipment> GetEquipmentSlots ()
        {
            return _equipment;
        }
    }
}

