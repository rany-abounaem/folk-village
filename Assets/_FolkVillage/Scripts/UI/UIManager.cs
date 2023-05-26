using FolkVillage.Player;
using UnityEngine;

namespace FolkVillage.UI
{
    public class UIManager : MonoBehaviour
    {
        private UIPanel _currentActivePanel;

        [SerializeField]
        private InventoryUI _inventoryUI;

        private PlayerEntity _player;

        public void Setup(InputControls inputControls, PlayerEntity player)
        {
            _player = player;
            _inventoryUI.Setup(_player);

            inputControls.UI.Inventory.performed += _ =>
            {
                ToggleUIPanel(_inventoryUI);
            };
        }

        public void ToggleUIPanel(UIPanel panel)
        {
            var __panelGameObject = panel.gameObject;

            if (!__panelGameObject.activeSelf)
            {
                if (_currentActivePanel != null)
                {
                    _currentActivePanel.gameObject.SetActive(false);
                }
                __panelGameObject.SetActive(true);
                _currentActivePanel = panel;
            }
            else
            {
                __panelGameObject.SetActive(false);
                _currentActivePanel = null;
            }
        }
    }
}

