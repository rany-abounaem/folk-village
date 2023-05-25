using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{ 
    public MovementComponent Movement { get; private set; }

    [Header("Animations")]
    [SerializeField]
    private List<Animator> _animators;

    public void Setup()
    {
        Movement = GetComponent<MovementComponent>();
        Movement.Setup(_animators);
    }
}
