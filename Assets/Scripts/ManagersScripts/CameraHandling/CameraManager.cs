using Cinemachine;
using Events;
using UnityEngine;

namespace ManagersScripts.CameraHandling
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera cvCamera;
        [SerializeField] private Transform player1Base;
        [SerializeField] private Transform player2Base;
        

        private void Start()
        {
            ToggleCamera();
        }

        private void ToggleCamera() // toggles the camera focus based on the current player turn
        {
            cvCamera.Follow = PlayerTurnManager.Instance.playerInTurnName switch
            {
                "Player1" => player1Base,
                "Player2" => player2Base,
                _ => cvCamera.Follow
            };
        }
        private void SetCamera(GameObject projectile) // sets the camera focus on the projectile
        {
            cvCamera.Follow = projectile.transform;

        }
        private void OnEnable()
        {
            CameraEvents.OnSetCamera += SetCamera;
            CameraEvents.OnToggleCamera += ToggleCamera;

        }

        private void OnDisable()
        {
            CameraEvents.OnSetCamera -= SetCamera;
            CameraEvents.OnToggleCamera -= ToggleCamera;

        }
    }
}