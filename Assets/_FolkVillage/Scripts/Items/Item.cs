using UnityEngine;

namespace FolkVillage.Items
{
    public delegate void IntCallback(int value);

    [CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Items/Item")]
    public class Item : ScriptableObject
    {
        [SerializeField]
        private string _itemName;
        [SerializeField]
        private string _description;
        [SerializeField]
        private bool _stackable;
        [SerializeField]
        private int _quantity;
        [SerializeField]
        private float _price;
        [SerializeField]
        private Sprite _icon;

        public event IntCallback OnQuantityUpdate;

        public string GetName()
        {
            return _itemName;
        }

        public string GetDescription()
        {
            return _description;
        }

        public int GetQuantity()
        {
            return _quantity;
        }

        public float GetPrice()
        {
            return _price;
        }

        public Sprite GetIcon()
        {
            return _icon;
        }

        public void SetQuantity(int quantity)
        {
            _quantity = quantity;
            OnQuantityUpdate?.Invoke(_quantity);
        }

        public bool IsStackable()
        {
            return _stackable;
        }
    }
}


