using FolkVillage.Items;
using FolkVillage.Player;
using System.Collections.Generic;
using UnityEngine;

namespace FolkVillage.Shops
{
    public class Shop : MonoBehaviour
    {
        [SerializeField]
        private string _welcomeDialogue;

        public event VoidCallback OnShopEntered;
        public event VoidCallback OnShopExit;

        private ContainerComponent _shopContainer;

        public void Setup()
        {
            _shopContainer = GetComponent<ContainerComponent>();
        }

        public string GetWelcomeDialogue()
        {
            return _welcomeDialogue;
        }

        public List<Item> GetShopItems()
        {
            return _shopContainer.GetItems();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PlayerEntity __player))
            {
                OnShopEntered?.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PlayerEntity __player))
            {
                OnShopExit?.Invoke();
            }
        }
    }
}

