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
        
        public delegate void SwitchCameraPriority(int cam1Priority, int cam2Priority);
        public static event SwitchCameraPriority OnSwitchCameraPriority;
        public static void OnSwitchCameraPriorityMethod(int cam1Priority, int cam2Priority)
        {
            if (OnSwitchCameraPriority != null)
            {
                OnSwitchCameraPriority(cam1Priority, cam2Priority);
            }
        }
        
        public delegate void ToggleDraggableCamera(bool camDragBool);
        public static event ToggleDraggableCamera OnToggleDraggableCamera;
        public static void OnToggleDraggableCameraMethod(bool camDragBool)
        {
            if (OnToggleDraggableCamera != null)
            {
                OnToggleDraggableCamera(camDragBool);
            }
        }
        
        public delegate void ForceRelease();
        public static event ForceRelease OnForceRelease;
        public static void OnForceReleaseMethod()
        {
            if (OnForceRelease != null)
            {
                OnForceRelease();
            }
        }
    }
}