using System.Collections.Generic;
using UnityEngine;
using FolkVillage.Animation;
using System;
using FolkVillage.Items;
using FolkVillage.Audio;

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
        private float _frameDuration = 0.1f;
        private float _timer = 0;

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
            _timer += Time.deltaTime;

            if (_timer > _frameDuration)
            {
                _timer -= _frameDuration;

                var __baseSprites = _baseSpriteDetails.GetAllSprites(_animatorState, _direction);

                _currentFrame = (_currentFrame + 1) % __baseSprites.Count;

                if (_currentFrame % 3 == 0)
                {
                    if (_animatorState != AnimatorState.Idle)
                    {
                        var _random = UnityEngine.Random.Range(0, 3);
                        var _footStep = _random == 0 ? "Foot_Step1" : _random == 1 ? "Foot_Step2" : "Foot_Step3";
                        AudioManager.instance.Play(_footStep);
                    }
                }

                for (var __i = 0; __i < _equipmentSlots.Count; __i++)
                {
                    var __equipmentSlot = _equipmentSlots[__i];
                    if (_equipmentSlots[__i] != null)
                    {
                        var __equipmentSlotSprites = __equipmentSlot.GetAnimationDetials().GetAllSprites(_animatorState, _direction);
                        var __currentEquipmentSlotSprite = __equipmentSlotSprites[_currentFrame];
                        _equipmentRenderers[__i].sprite = __currentEquipmentSlotSprite;
                    }
                    else
                    {
                        _equipmentRenderers[__i].sprite = null;
                    }
                }

                _baseRenderer.sprite = __baseSprites[_currentFrame];
            }
                
        }
    }
}

