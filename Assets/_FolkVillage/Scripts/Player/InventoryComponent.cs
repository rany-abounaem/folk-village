using FolkVillage.Items;
using FolkVillage.UI;
using UnityEngine;

namespace FolkVillage.Player
{
    public delegate void VoidCallback();
    public class InventoryComponent : ContainerComponent
    {
        private int _money;
        public event IntCallback OnMoneyUpdate;
        public bool RemoveMoney(int quantity)
        {
            if (_money >= quantity)
            {
                _money -= quantity;
                OnMoneyUpdate?.Invoke(_money);
                return true;
            }
            return false;
        }

        public void AddMoney(int quantity)
        {
            _money += quantity;
            OnMoneyUpdate?.Invoke(_money);
        }

        public int GetMoney()
        {
            return _money;
        }
    }
}
