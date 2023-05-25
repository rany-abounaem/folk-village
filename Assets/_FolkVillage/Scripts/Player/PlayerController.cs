using FolkVillage.Input;
using UnityEngine;

namespace FolkVillage.Player
{
    [CreateAssetMenu(fileName = "PlayerController", menuName = "ScriptableObjects/Player/PlayerController")]
    public class PlayerController : ScriptableObject
    {
        private InputControls _input;
        private PlayerEntity _player;
        
        public void Setup(InputControls inputControls, PlayerEntity player)
        {
            _player = player;
            inputControls.Game.Movement.performed += _ =>
            {
                var __movement = _.ReadValue<Vector2>();
                _player.Movement.SetMovementInput(__movement);
            };
        }
    }
}

