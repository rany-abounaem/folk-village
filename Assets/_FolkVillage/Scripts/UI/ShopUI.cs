using FolkVillage.Player;
using FolkVillage.Shops;
using TMPro;
using UnityEngine;

namespace FolkVillage.UI
{
    public class ShopUI : UIPanel
    {
        private InventoryComponent _inventory;

        [SerializeField]
        private TextMeshProUGUI _welcomeText;

        public void Setup(PlayerEntity player, Shop shop)
        {            
            //for (var __i = 0; __i < _inventorySlots.Count; __i++)
            //{
            //    _inventorySlots[__i].Setup(__i);
            //    _inventorySlots[__i].OnSlotClick += TryEquip;
            //}

            _inventory = player.Inventory;
            _welcomeText.text = shop.GetWelcomeDialogue();

            Refresh();

            _inventory.OnContainerUpdate += RefreshInventory;
            //_equipment.OnEquipmentUpdate += RefreshEquipment;
        }

        public void Refresh()
        {
            RefreshInventory();
            RefreshEquipment();
        }

        private void RefreshInventory()
        {
            var __inventoryItems = _inventory.GetItems();
            //for (var __i = 0; __i < _inventorySlots.Count; __i++)
            //{
            //    if (__i >= __inventoryItems.Count)
            //    {
            //        _inventorySlots[__i].UpdateSlot(null);
            //        continue;
            //    }
            //    _inventorySlots[__i].UpdateSlot(__inventoryItems[__i]);
            //}
        }

        private void RefreshEquipment()
        {
            //var __equipmentItems = _equipment.GetEquipmentSlots();
            //for (var __i = 0; __i < _equipmentSlots.Count; __i++)
            //{
            //    if (__i >= __equipmentItems.Count)
            //    {
            //        _equipmentSlots[__i].UpdateSlot(null);
            //        continue;
            //    }
            //    _equipmentSlots[__i].UpdateSlot(__equipmentItems[__i]);
            //}
        }
    }
}

