using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FolkVillage.UI
{
    public abstract class SlotUI : MonoBehaviour, IPointerClickHandler
    {
        private int _slotIndex;
        [SerializeField]
        private Image _slotImage;
        [SerializeField]
        private Sprite _defaultSprite;
        public virtual void OnPointerClick(PointerEventData eventData)
        {
        }

        public virtual void Setup(int slotIndex)
        {
            _slotIndex = slotIndex;
            _slotImage.sprite = _defaultSprite;
        }
    }
}

