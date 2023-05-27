using UnityEngine;

public delegate void StringCallback (string s);

namespace FolkVillage.UI
{
    [CreateAssetMenu(fileName = "PopupEventChannel", menuName = "ScriptableObjects/UI/PopupEventChannel")]
    public class PopupEventChannel : ScriptableObject
    {
        public event StringCallback OnStringUpdate;

        public void Raise(string s)
        {
            OnStringUpdate?.Invoke(s);
        }
    }
}

