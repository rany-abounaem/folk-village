using UnityEngine;

namespace FolkVillage.Items
{
    public delegate void IntCallback(int value);

    [CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Items/Item")]
    public class Item : ScriptableObject, ISlottable
    {
        [SerializeField]
        private string _itemName;
        [SerializeField]
        private string _description;
        [SerializeField]
        private bool _stackable;
        [SerializeField]
        private int _price;
        [SerializeField]
        private Sprite _icon;

        public string GetName()
        {
            return _itemName;
        }

        public string GetDescription()
        {
            return _description;
        }

        public int GetPrice()
        {
            return _price;
        }

        public Sprite GetIcon()
        {
            return _icon;
        }

        public bool IsStackable()
        {
            return _stackable;
        }
    }
}


