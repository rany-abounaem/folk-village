using FolkVillage.Player;
using UnityEngine;

namespace FolkVillage.UI
{
    public class UIManager : MonoBehaviour
    {
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
            panel.gameObject.SetActive(!panel.gameObject.activeSelf);
        }
    }
}

