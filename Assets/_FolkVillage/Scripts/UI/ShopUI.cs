using FolkVillage.Items;
using FolkVillage.Player;
using FolkVillage.Shops;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FolkVillage.UI
{
    public class ShopUI : UIPanel
    {
        [SerializeField]
        private List<SlotUI> _shopContainerSlots;
        [SerializeField]
        private List<SlotUI> _inventorySlots;
        [SerializeField]
        private TextMeshProUGUI _playerMoney;
        [SerializeField]
        private TextMeshProUGUI _welcomeText;


        [SerializeField]
        private Image _shopKeepersImage;

        private ContainerComponent _shopContainer;
        private InventoryComponent _inventory;

        public void Setup(PlayerEntity player, ShopEntity shop)
        {
            for (var __i = 0; __i < _shopContainerSlots.Count; __i++)
            {
                _shopContainerSlots[__i].Setup(__i);
                _shopContainerSlots[__i].OnSlotClick += (index) => shop.BuyItemFromShop(index);
            }

            for (var __i = 0; __i < _inventorySlots.Count; __i++)
            {
                _inventorySlots[__i].Setup(__i);
                _inventorySlots[__i].OnSlotClick += (index) => shop.SellItemToShop(index);
            }

            _inventory = player.Inventory;
            _playerMoney.text = _inventory.GetMoney().ToString();
            _shopContainer = shop.GetShopContainer();
            _welcomeText.text = shop.GetWelcomeDialogue();
            _shopKeepersImage.sprite = shop.GetShopkeerImage();

            Refresh();

            shop.OnShopTransaction += Refresh;
        }

        public void Unsubscribe()
        {
            for (var __i = 0; __i < _shopContainerSlots.Count; __i++)
            {
                _shopContainerSlots[__i].Unsubscribe();
            }

            for (var __i = 0; __i < _inventorySlots.Count; __i++)
            {
                _inventorySlots[__i].Unsubscribe();
            }
        }

        public void Refresh()
        {
            RefreshShopContainer();
            RefreshPlayerInventory();
        }

        private void RefreshShopContainer()
        {
            var __shopContainerItems = _shopContainer.GetItems();
            
            for (var __i = 0; __i < _shopContainerSlots.Count; __i++)
            {
                if (__i >= __shopContainerItems.Count)
                {
                    _shopContainerSlots[__i].UpdateSlot(null);
                    continue;
                }
                _shopContainerSlots[__i].UpdateSlot(__shopContainerItems[__i]);
            }
        }

        private void RefreshPlayerInventory()
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
            _playerMoney.text = _inventory.GetMoney().ToString();
        }

        public override void Close()
        {
            base.Close();
            Unsubscribe();
        }

    }
}

