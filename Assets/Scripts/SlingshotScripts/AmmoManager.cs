using Data;
using ManagersScripts;
using UnityEngine;

namespace SlingshotScripts
{
    public class AmmoManager : MonoBehaviour
    {
        [SerializeField] private GameObject activeBall;
        [SerializeField] private GameObject ballPrefab;
        [SerializeField] private Transform origin;
        [SerializeField] private Rigidbody2D originRigidBody2D;
        [SerializeField] private PlayerData playerData;
    

        private void Update()
        {
            if (playerData.playerName == PlayerTurnManager.Instance.playerInTurnName)
            {
                LoadAmmo();
            }
        }

        private void LoadAmmo() //instantiates a ball and sets its origin if ball is destroyed
        {
            if (activeBall) return;
            activeBall = Instantiate(ballPrefab, origin.position, origin.rotation );
            activeBall.GetComponent<SpringJoint2D>().connectedBody = originRigidBody2D;
            playerData.equippedAmmo = activeBall.tag;
        }
    }
}
