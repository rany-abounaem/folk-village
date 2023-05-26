using FolkVillage.Input;
using FolkVillage.Player;
using FolkVillage.Shops;
using FolkVillage.UI;
using System.Collections.Generic;
using UnityEngine;

namespace FolkVillage.Systems
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private InputManager _inputManager;
        [SerializeField]
        private PlayerController _playerController;
        [SerializeField]
        private UIManager _UIManager;
        [SerializeField]
        private GameObject _player;
        [SerializeField]
        private List<ShopEntity> _shops;

        private InputControls _controls;

        void Start()
        {
            // Initializing input
            _inputManager.Setup();
            _controls = _inputManager.GetControls();

            // Initializing player (could be retrieved from saved data instead)
            var __playerEntity = _player.GetComponent<PlayerEntity>();
            __playerEntity.Setup();

            // Setup shops
            foreach (var __shop in _shops)
            {
                __shop.Setup(__playerEntity.Inventory);
            }

            // Initialize UI
            _UIManager.Setup(_controls, __playerEntity, _shops);

            // Assigning player to player controller (if the user can play with more than one character)
            _playerController.Setup(_controls, __playerEntity);
        }
    }
}

