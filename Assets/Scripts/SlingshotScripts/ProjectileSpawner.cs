using ManagersScripts;
using UnityEngine;

namespace SlingshotScripts
{
    public class ProjectileSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject activeBall;
        [SerializeField] private GameObject ballPrefab;
        [SerializeField] private Transform origin;
        [SerializeField] private Rigidbody2D originRigidBody2D;
    

        private void Update()
        {
            //instantiates a ball and gives it origin if ball is destroyed
            if (ballPrefab.CompareTag(PlayerTurnManager.Instance.playerInTurnName))
            {
                if (activeBall) return;
                activeBall = Instantiate(ballPrefab, origin.position, origin.rotation );
                activeBall.GetComponent<SpringJoint2D>().connectedBody = originRigidBody2D;
            }
        }
    }
}
