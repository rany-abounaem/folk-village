using System.Collections.Generic;
using UnityEngine;
using FolkVillage.Animation;
using System;
using FolkVillage.Items;

// Should be a parent class and states would inherit that parent class
public enum AnimatorState
{
    Idle = 0,
    Walk = 1,
}

namespace FolkVillage.Player
{
    [Serializable]
    public class DirectionalSprites
    {
        [SerializeField]
        private List<SpriteList> _directionBasedSprites = new List<SpriteList>(4);

        public List<SpriteList> GetSpritesWithDirection()
        {
            return _directionBasedSprites;
        }
    }


    [Serializable]
    public class SpriteList
    {
        [SerializeField]
        private List<Sprite> _sprites;

        public List<Sprite> GetFrameSprites()
        {
            return _sprites;
        }
    }

    public class AnimatorComponent : MonoBehaviour
    {
        [SerializeField]
        private AnimationDetails _baseSpriteDetails;

        [Header("Renderers")]
        [SerializeField]
        private SpriteRenderer _baseRenderer;
        [SerializeField]
        private List<SpriteRenderer> _equipmentRenderers;

        private List<Equipment> _equipmentSlots;

        private AnimatorState _animatorState;
        private Vector2 _movement;
        private PlayerDirection _direction;
        private int _currentFrame = 0;
        private int _currentSpriteIndex = 0;
        private int _framesPerSprite = 60;

        public void Setup(List<Equipment> equipment)
        {
            _equipmentSlots = equipment;
        }

        public void SetState(AnimatorState state)
        {
            _animatorState = state;
        }

        public void SetMovement(Vector2 movement)
        {
            _movement = movement;

            if (_movement.x > 0)
            {
                _direction = PlayerDirection.Right;
            }
            else if (_movement.x < 0)
            {
                _direction = PlayerDirection.Left;
            }
            else if (_movement.y > 0)
            {
                _direction = PlayerDirection.Up;
            }
            else if (_movement.y < 0)
            {
                _direction = PlayerDirection.Down;
            }
        }

        private void Update()
        {
            _currentFrame++;

            if (_currentFrame >= _framesPerSprite)
            {
                _currentFrame = 0;
                _currentSpriteIndex++;

                var __baseSprites = _baseSpriteDetails.GetAllSprites(_animatorState, _direction);


                if (_currentSpriteIndex >= __baseSprites.Count)
                {
                    _currentSpriteIndex = 0;
                }

                for (var __i = 0; __i < _equipmentSlots.Count; __i++)
                {
                    var __equipmentSlot = _equipmentSlots[__i];
                    if (_equipmentSlots[__i] != null)
                    {
                        var __equipmentSlotSprites = __equipmentSlot.GetAnimationDetials().GetAllSprites(_animatorState, _direction);
                        var __currentEquipmentSlotSprite = __equipmentSlotSprites[_currentSpriteIndex];
                        _equipmentRenderers[__i].sprite = __currentEquipmentSlotSprite;
                    }
                    else
                    {
                        _equipmentRenderers[__i].sprite = null;
                    }
                }

                _baseRenderer.sprite = __baseSprites[_currentSpriteIndex];
            } 
        }
    }
}

