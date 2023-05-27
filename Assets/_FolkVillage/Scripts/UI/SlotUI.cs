using FolkVillage.Items;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FolkVillage.UI
{
    public abstract class SlotUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private int _slotIndex;
        [SerializeField]
        private Image _slotImage;
        [SerializeField]
        private Sprite _defaultSprite;
        private ISlottable _slottable;

        public event IntCallback OnSlotClick;
        public event IntCallback OnSlotPointerEnter;
        public event IntCallback OnSlotPointerExit;
        public virtual void OnPointerClick(PointerEventData eventData)
        {
            OnSlotClick?.Invoke(_slotIndex);
        }

        public virtual void Setup(int slotIndex)
        {
            _slotIndex = slotIndex;
            _slotImage.sprite = _defaultSprite;
            _slottable = null;
        }

        public virtual void UpdateSlot(ISlottable slottable)
        {
            _slottable = slottable;
            if (slottable != null)
            {
                _slotImage.sprite = _slottable.GetIcon();
            }
            else
            {
                _slotImage.sprite = _defaultSprite;
            }
        }

        public void Unsubscribe()
        {
            OnSlotClick = null;
            OnSlotPointerEnter = null;
            OnSlotPointerExit = null;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnSlotPointerEnter?.Invoke(_slotIndex);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnSlotPointerExit?.Invoke(_slotIndex); ;
        }
    }
}

