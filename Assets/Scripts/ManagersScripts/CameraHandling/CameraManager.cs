using System.Collections;
using Cinemachine;
using Events;
using UnityEngine;

namespace ManagersScripts.CameraHandling
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera cvCamera;
        [SerializeField] private CinemachineVirtualCamera draggableCamera;
        [SerializeField] private Transform player1Base;
        [SerializeField] private Transform player2Base;
        private bool _isRunning = false;

        private void Start()
        {
            ToggleCamera();
        }

        private void ToggleCamera() // toggles the camera focus based on the current player turn
        {
            switch (PlayerTurnManager.Instance.playerInTurnName)
            {
                case "Player1":
                    cvCamera.Follow = player1Base;
                    draggableCamera.transform.position = new Vector3(player1Base.position.x, player1Base.position.y, draggableCamera.transform.position.z);
                    break;
                case "Player2":
                    draggableCamera.transform.position = new Vector3(player2Base.position.x, player2Base.position.y, draggableCamera.transform.position.z);
                    cvCamera.Follow = player2Base;
                    break;
            }

            StartCoroutine(SwitchCountdown());
        }
        private void SetCamera(GameObject projectile) // sets the camera focus on the projectile
        {
            cvCamera.Follow = projectile.transform;

        }
        private void SwitchPriority(int cam1Priority, int cam2Priority)
        {
            cvCamera.Priority = cam1Priority;
            draggableCamera.Priority = cam2Priority;
        }
        private IEnumerator SwitchCountdown()
        {
            if (!_isRunning)
            {
                _isRunning = true;
                yield return new WaitForSeconds(0.1f);
                CameraEvents.OnSwitchCameraPriorityMethod(0,1);
                CameraEvents.OnToggleDraggableCameraMethod(true);
                _isRunning = false;
            }
        }
        private void OnEnable()
        {
            CameraEvents.OnSetCamera += SetCamera;
            CameraEvents.OnToggleCamera += ToggleCamera;
            CameraEvents.OnSwitchCameraPriority += SwitchPriority;
        }

        private void OnDisable()
        {
            CameraEvents.OnSetCamera -= SetCamera;
            CameraEvents.OnToggleCamera -= ToggleCamera;
            CameraEvents.OnSwitchCameraPriority -= SwitchPriority;

        }
    }
}