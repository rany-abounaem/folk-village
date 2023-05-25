using System.Collections.Generic;
using UnityEngine;

namespace FolkVillage.Player
{
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField]
        private float _movementSpeed;

        private AnimatorComponent _animator;

        private Vector2 _movementInput;

        public void Setup(AnimatorComponent animator)
        {
            _animator = animator;
        }
        public void SetMovementInput(Vector2 movementInput)
        {

            if (movementInput.magnitude == 0)
            {
                _animator.SetState(AnimatorState.Idle);
                _movementInput = movementInput;
            }
            else
            {
                _movementInput = movementInput;
                _animator.SetMovement(movementInput);
                _animator.SetState(AnimatorState.Walk);
            }
            

        }

        private void Update()
        {
            gameObject.transform.Translate(_movementSpeed * Time.deltaTime * _movementInput);
        }
    }
}

