using FolkVillage.Input;
using FolkVillage.Player;
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
        private GameObject _player;

        private InputControls _controls;

        void Start()
        {
            // Initializing input
            _inputManager.Setup();
            _controls = _inputManager.GetControls();

            // Initializing player (could be retrieved from saved data instead)
            var __playerEntity = _player.GetComponent<PlayerEntity>();
            __playerEntity.Setup();

            // Assigning player to player controller (if the user can play with more than one character)
            _playerController.Setup(_controls, __playerEntity);
        }

        void Update()
        {

        }
    }
}

