using UnityEngine;

namespace Events
{
    public class CameraEvents : MonoBehaviour
    { // EVENTS FOR CAMERA ACTIONS
        public delegate void SetCamera(GameObject activeBall);
        public static event SetCamera OnSetCamera;
        public static void OnSetCameraMethod(GameObject activeBall)
        {
            if (OnSetCamera != null)
            {
                OnSetCamera(activeBall);
            }
        }
        
        public delegate void ToggleCamera();
        public static event ToggleCamera OnToggleCamera;
        public static void OnToggleCameraMethod()
        {
            if (OnToggleCamera != null)
            {
                OnToggleCamera();
            }
        }
    }
}