using FolkVillage.Player;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FolkVillage.Animation
{
    [CreateAssetMenu(fileName = "AnimationDetails", menuName = "ScriptableObjects/Animation/AnimationDetails")]
    [Serializable]
    public class AnimationDetails : ScriptableObject
    {
        [SerializeField]
        private List<DirectionalSprites> _typeAndDirectionBasedSprites;

        public List<Sprite> GetAllSprites(AnimatorState state, PlayerDirection direction)
        {
            return _typeAndDirectionBasedSprites[(int)state].GetSpritesWithDirection()[(int)direction].GetFrameSprites();
        }
    }
}

