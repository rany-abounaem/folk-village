using FolkVillage.Audio;
using FolkVillage.Player;
using FolkVillage.Shops;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

        [SerializeField]
        private PopupEventChannel _popupEventChannel;
        [SerializeField]
        private TextMeshProUGUI _popupText;
        private Coroutine _popupCoroutine;

        private PlayerEntity _player;

        public void Setup(InputControls inputControls, PlayerEntity player, List<ShopEntity> shops)
        {
            _player = player;
            _inventoryUI.Setup(_player);

            foreach (var __shop in shops)
            {
                __shop.OnShopEntered += () =>
                {
                    HandleShopEntered(__shop);
                };

                __shop.OnShopExit += () => {
                    HandleShopExit();
                }; ;
            }

            inputControls.UI.Inventory.performed += _ =>
            {
                ToggleUIPanel(_inventoryUI);
            };

            _popupEventChannel.OnStringUpdate += (s) =>
            {
                if (_popupCoroutine != null)
                {
                    StopCoroutine(_popupCoroutine);
                    _popupCoroutine = null;
                }
                StartCoroutine(PopupCoroutine(s));
            };


        }

        public void Tick(float delta)
        {
            _shopUI.Tick(delta);
        }

        private void CloseCurrentPanel()
        {
            if (_currentActivePanel != null)
            {
                _currentActivePanel.gameObject.SetActive(false);
                _currentActivePanel.Close();
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

        private void HandleShopEntered(ShopEntity shop)
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

        public void ShowPopup(string s)
        {
            _popupText.gameObject.SetActive(true);
            _popupText.text = s;
        }

        public void HidePopup()
        {
            _popupText.gameObject.SetActive(false);
        }

        private IEnumerator PopupCoroutine(string s)
        {
            ShowPopup(s);
            yield return new WaitForSeconds(1.5f);
            HidePopup();
        }
    }
}

