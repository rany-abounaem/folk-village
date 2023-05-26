using FolkVillage.Items;
using FolkVillage.Player;
using System.Collections.Generic;
using UnityEngine;

namespace FolkVillage.Shops
{
    public class ShopEntity : MonoBehaviour
    {
        [SerializeField]
        private string _welcomeDialogue;
        private Sprite _icon;

        public event VoidCallback OnShopEntered;
        public event VoidCallback OnShopExit;
        public event VoidCallback OnShopTransaction;

        private ContainerComponent _shopContainer;
        private InventoryComponent _playerInventory;

        public void Setup(InventoryComponent inventory)
        {
            _playerInventory = inventory;
            _shopContainer = GetComponent<ContainerComponent>();
            _icon = GetComponent<SpriteRenderer>().sprite;
        }

        public string GetWelcomeDialogue()
        {
            return _welcomeDialogue;
        }

        public ContainerComponent GetShopContainer()
        {
            return _shopContainer;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PlayerEntity __player))
            {
                OnShopEntered?.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PlayerEntity __player))
            {
                OnShopExit?.Invoke();
            }
        }

        public bool BuyItemFromShop(int index)
        {
            Debug.Log("Buy Item at Index " + index);
            var __item = _shopContainer.GetItem(index);
            if (__item == null) { return false; }
            if (_playerInventory.AddItem(__item))
            {
                if (_playerInventory.RemoveMoney(__item.GetPrice()))
                {
                    _shopContainer.RemoveItem(__item);
                    OnShopTransaction?.Invoke();
                    return true;
                }
                else
                {
                    _playerInventory.RemoveItem(__item);
                }
            }
            return false;
        }

        public bool SellItemToShop(int index)
        {
            Debug.Log("Sell Item at Index " + index);
            var __item = _playerInventory.GetItem(index);
            if (__item == null) { return false; }
            if (_shopContainer.AddItem(__item))
            {
                _playerInventory.AddMoney(__item.GetPrice());
                _playerInventory.RemoveItem(__item);
                OnShopTransaction?.Invoke();
                return true;
            }
            return false;
        }

        public Sprite GetShopkeerImage()
        {
            return _icon;
        }
    }
}

