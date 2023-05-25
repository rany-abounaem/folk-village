using FolkVillage.Animation;
using System.Collections.Generic;
using UnityEngine;

namespace FolkVillage.Items
{
    public abstract class Equipment : Item
    {
        [SerializeField]
        private AnimationDetails _animationDetails;

        [SerializeField]
        private EquipmentSlot _slot;

        public EquipmentSlot GetSlot() 
        {
            return _slot;
        }

        public AnimationDetails GetAnimationDetials()
        {
            return _animationDetails;
        }
    }
}

