using FolkVillage.Player;
using FolkVillage.Shops;
using System.Collections.Generic;
using UnityEngine;

namespace FolkVillage.UI
{
    public class UIManager : MonoBehaviour
    {
        private UIPanel _currentActivePanel;

        [SerializeField]
        private InventoryUI _inventoryUI;
        [SerializeField]
        private ShopUI _shopUI;

        private PlayerEntity _player;

        public void Setup(InputControls inputControls, PlayerEntity player, List<Shop> shops)
        {
            _player = player;
            _inventoryUI.Setup(_player);

            foreach (var __shop in shops)
            {
                Debug.Log("helped");
                __shop.OnShopEntered += () =>
                {
                    HandleShopEntered(__shop);
                };

                __shop.OnShopExit += HandleShopExit;
            }

            inputControls.UI.Inventory.performed += _ =>
            {
                ToggleUIPanel(_inventoryUI);
            };
        }

        private void CloseCurrentPanel()
        {
            if (_currentActivePanel != null)
            {
                _currentActivePanel.gameObject.SetActive(false);
                _currentActivePanel = null;
            }
        }

        private void ToggleUIPanel(UIPanel panel)
        {
            var __panelGameObject = panel.gameObject;

            if (!__panelGameObject.activeSelf)
            {
                OpenPanel(panel);
            }
            else
            {
                CloseCurrentPanel();
            }
        }

        private void OpenPanel(UIPanel panel)
        {
            CloseCurrentPanel();
            panel.gameObject.SetActive(true);
            _currentActivePanel = panel;
        }

        private void HandleShopEntered(Shop shop)
        {
            _shopUI.Setup(_player, shop);
            OpenPanel(_shopUI);
        }

        private void HandleShopExit()
        {
            if (_currentActivePanel == _shopUI)
            {
                CloseCurrentPanel();
            }
        }
    }
}

