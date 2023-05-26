using System.Collections.Generic;
using UnityEngine;

public enum PlayerDirection
{
    Down = 0,
    Up = 1,
    Right = 2,
    Left = 3,
}

namespace FolkVillage.Player
{
    public class PlayerEntity : MonoBehaviour
    {
        public MovementComponent Movement { get; private set; }
        public InventoryComponent Inventory { get; private set; }
        public EquipmentComponent Equipment { get; private set; }
        public AnimatorComponent Animator { get; private set; }
        public Rigidbody2D Rigidbody { get; private set; }

        public void Setup()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            Inventory = GetComponent<InventoryComponent>();
            Equipment = GetComponent<EquipmentComponent>();
            Equipment.Setup(Inventory);
            Animator = GetComponent<AnimatorComponent>();
            Animator.Setup(Equipment.GetEquipmentSlots());
            Movement = GetComponent<MovementComponent>();
            Movement.Setup(Animator, Rigidbody);

        }
    }
}

