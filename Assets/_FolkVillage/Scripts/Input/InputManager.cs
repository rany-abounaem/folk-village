using UnityEngine;

namespace FolkVillage.Input
{
    [CreateAssetMenu(fileName = "InputManager", menuName = "ScriptableObjects/Input")]
    public class InputManager : ScriptableObject
    {
        private InputControls _inputControls;

        public void Setup()
        {
            _inputControls = new InputControls();
            _inputControls.Enable();
        }

        public InputControls GetControls()
        {
            return _inputControls;
        }
    }
}


