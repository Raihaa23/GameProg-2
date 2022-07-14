using System;
using Cinemachine;
using Events;
using SlingshotScripts;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UIElements;

namespace ManagersScripts.CameraHandling
{
    public class CameraPanning : MonoBehaviour
    {
        [SerializeField] private InputHandler inputHandler;
        [SerializeField] private CameraPanningMovement cameraMovement;
        private bool _canDrag = false;
        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (inputHandler.MouseInputDown)
            {
                cameraMovement.CheckForConfiner(_canDrag);
            }
            if (inputHandler.MouseInput)
            {
                cameraMovement.CheckForConfinerDrag();
            }
            if (inputHandler.MouseInputUp)
            {
                cameraMovement.CheckForConfinerRelease();
            }
        }

        private void ForceReleaseConfiner()
        {
            cameraMovement.CheckForConfinerRelease();
        }
        private void ToggleCameraDrag(bool camDragBool)
        {
            _canDrag = camDragBool;
        }

        private void OnEnable()
        {
            CameraEvents.OnToggleDraggableCamera += ToggleCameraDrag;
            CameraEvents.OnForceRelease += ForceReleaseConfiner;
        }

        private void OnDisable()
        {
            CameraEvents.OnToggleDraggableCamera -= ToggleCameraDrag;
            CameraEvents.OnForceRelease -= ForceReleaseConfiner;
        }
    }
}