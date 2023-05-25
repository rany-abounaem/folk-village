using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed;

    private List<Animator> _animators;

    private Vector2 _movementInput;
    private Vector2 _animatorMovement;

    public void Setup(List<Animator> animators)
    {
        _animators = animators;
    }
    public void SetMovementInput(Vector2 movementInput)
    {
        if (movementInput.magnitude == 0)
        {
            // Adjust animator movement values to become idle based on last movement direction
            if (_movementInput.x > 0)
            {
                _animatorMovement = new Vector2(0.1f, 0);
            }
            else if (_movementInput.x < 0)
            {
                _animatorMovement = new Vector2(-0.1f, 0);
            }
            else if (_movementInput.y > 0)
            {
                _animatorMovement = new Vector2(0, 0.1f);
            }
            else if (_movementInput.y < 0)
            {
                _animatorMovement = new Vector2(0, -0.1f);
            }
        }
        else
        {
            _animatorMovement = movementInput;
        }
        _movementInput = movementInput;

    }

    private void Update()
    {
        gameObject.transform.Translate(_movementSpeed * Time.deltaTime * _movementInput);

        foreach (var __animator in _animators)
        {
            __animator.SetFloat("MovementX", _animatorMovement.x);
            __animator.SetFloat("MovementY", _animatorMovement.y);
        }
    }
}
