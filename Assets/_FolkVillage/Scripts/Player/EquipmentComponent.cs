using FolkVillage.Audio;
using FolkVillage.Items;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentSlot { Body = 0, Hat = 1 };

namespace FolkVillage.Player
{
    public class EquipmentComponent : MonoBehaviour
    {
        [SerializeField]
        private List<Equipment> _equipment = new List<Equipment>(2);

        private InventoryComponent _inventory;

        public event VoidCallback OnEquipmentUpdate;

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
                OnEquipmentUpdate?.Invoke();
                AudioManager.instance.Play("Equip");
                return true;
            }
            return false;
            
        }

        public bool Equip(int index)
        {
            var __equipmentItem = _inventory.GetItem(index) as Equipment;

            if (__equipmentItem != null)
            {
                if (_inventory.RemoveItem(__equipmentItem))
                {
                    var __slot = __equipmentItem.GetSlot();
                    var __slotIndex = (int)__slot;
                    if (_equipment[__slotIndex] != null)
                    {
                        DeEquip(__slot);
                    }
                    _equipment[__slotIndex] = __equipmentItem;
                    OnEquipmentUpdate?.Invoke();
                    AudioManager.instance.Play("Equip");
                    return true;
                }
                return false;
            }
            return false;
            

        }

        public bool DeEquip (EquipmentSlot slot)
        {
            var __slotIndex = (int)slot;
            if (_inventory.AddItem(_equipment[__slotIndex]))
            {
                _equipment[__slotIndex] = null;
                OnEquipmentUpdate?.Invoke();
                AudioManager.instance.Play("DeEquip");
                return true;
            }
            return false;
        }
        public bool DeEquip(int index)
        {
            if (_equipment[index] == null)
                return false;
            if (_inventory.AddItem(_equipment[index]))
            {
                _equipment[index] = null;
                OnEquipmentUpdate?.Invoke();
                AudioManager.instance.Play("DeEquip");
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

