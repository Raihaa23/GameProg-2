using Cinemachine;
using UnityEngine;
using Events;

namespace ManagersScripts
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

        private void ToggleCamera()
        {
            cvCamera.Follow = PlayerTurnManager.Instance.playerInTurnName switch
            {
                "Player1" => player1Base,
                "Player2" => player2Base,
                _ => cvCamera.Follow
            };
        }
        private void SetCamera(GameObject projectile)
        {
            cvCamera.Follow = projectile.transform;

        }
        private void OnEnable()
        {
            GameEvents.OnSetCamera += SetCamera;
            GameEvents.OnToggleCamera += ToggleCamera;

        }

        private void OnDisable()
        {
            GameEvents.OnSetCamera -= SetCamera;
            GameEvents.OnToggleCamera -= ToggleCamera;

        }
    }
}