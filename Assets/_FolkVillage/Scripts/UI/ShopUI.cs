using FolkVillage.Items;
using FolkVillage.Player;
using FolkVillage.Shops;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEditor.Progress;

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
        private TooltipUI _tooltip;



        [SerializeField]
        private Image _shopKeepersImage;

        private ContainerComponent _shopContainer;
        private InventoryComponent _inventory;

        public void Setup(PlayerEntity player, ShopEntity shop)
        {
            _inventory = player.Inventory;
            _playerMoney.text = _inventory.GetMoney().ToString();
            _shopContainer = shop.GetShopContainer();
            _welcomeText.text = shop.GetWelcomeDialogue();
            _shopKeepersImage.sprite = shop.GetShopkeerImage();


            for (var __i = 0; __i < _shopContainerSlots.Count; __i++)
            {
                _shopContainerSlots[__i].Setup(__i);
                _shopContainerSlots[__i].OnSlotClick += (index) => shop.BuyItemFromShop(index);
                _shopContainerSlots[__i].OnSlotPointerEnter += (index) => 
                {
                    var __item = _shopContainer.GetItem(index);
                    if (__item == null)
                    {
                        return;
                    }
                    ShowTooltip("Price: " + __item.GetPrice()); 
                };
                _shopContainerSlots[__i].OnSlotPointerExit += (index) => { HideTooltip();  };
            }

            for (var __i = 0; __i < _inventorySlots.Count; __i++)
            {
                _inventorySlots[__i].Setup(__i);
                _inventorySlots[__i].OnSlotClick += (index) => shop.SellItemToShop(index);
                _inventorySlots[__i].OnSlotPointerEnter += (index) =>
                {
                    var __item = _inventory.GetItem(index);
                    if (__item == null)
                    {
                        return;
                    }
                    ShowTooltip("Price: " + __item.GetPrice());
                };
                _inventorySlots[__i].OnSlotPointerExit += (index) => { HideTooltip();  };
            }

            Refresh();

            shop.OnShopTransaction += Refresh;
        }

        private void ShowTooltip(string s)
        {
            _tooltip.gameObject.SetActive(true);
            _tooltip.UpdateTooltip(s);
        }

        private void HideTooltip()
        {
            _tooltip.gameObject.SetActive(false);
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

        public void Tick(float delta)
        {
            if (_tooltip.gameObject.activeSelf)
            {
                var __rectTransform = (RectTransform)_tooltip.transform;
                _tooltip.transform.position = Mouse.current.position.ReadValue() + new Vector2(__rectTransform.rect.width/2, __rectTransform.rect.height/2);
            }
        }

    }
}

