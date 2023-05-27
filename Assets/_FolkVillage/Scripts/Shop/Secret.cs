using FolkVillage.Player;
using FolkVillage.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secret : MonoBehaviour
{
    [SerializeField]
    private PopupEventChannel _popupChannel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerEntity __player))
        {
            _popupChannel.Raise("This old shop of your friend has been closed. Maybe this is the last time you will see this shop.");
        }
    }
}
