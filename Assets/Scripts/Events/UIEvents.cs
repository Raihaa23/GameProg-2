using UnityEngine;

namespace Events
{
    public class UIEvents : MonoBehaviour
    { // EVENTS FOR UI MANIPULATION
        public delegate void ToggleAmmoButton();
        public static event ToggleAmmoButton OnToggleAmmoButton;
        public static void OnToggleAmmoButtonMethod()
        {
            if (OnToggleAmmoButton != null)
            {
                OnToggleAmmoButton();
            }
        }
        
        public delegate void ToggleAmmoText();
        public static event ToggleAmmoText OnToggleAmmoText;
        public static void OnToggleAmmoTextMethod()
        {
            if (OnToggleAmmoText != null)
            {
                OnToggleAmmoText();
            }
        }
    }
}