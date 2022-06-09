using System;
using Data;
using ManagersScripts;
using UnityEngine;
using Events;

namespace SlingshotScripts
{
    public class AmmoManager : MonoBehaviour
    {
        [SerializeField] private GameObject activeBall;
        [SerializeField] private GameObject ballPrefab;
        [SerializeField] private Transform origin;
        [SerializeField] private Rigidbody2D originRigidBody2D;
        [SerializeField] private PlayerData playerData;
        

        private void Start()
        {
            LoadAmmo();
        }

        private void LoadAmmo() //instantiates a ball and sets its origin if ball is destroyed
        {
            if (playerData.playerName != PlayerTurnManager.Instance.playerInTurnName) return;
            if (activeBall) return;
            activeBall = Instantiate(ballPrefab, origin.position, origin.rotation);
            activeBall.GetComponent<SpringJoint2D>().connectedBody = originRigidBody2D;
            playerData.equippedAmmo = activeBall.tag;
            PlayerTurnManager.Instance.isProjectileReleased = false;
        }
        
        private void OnEnable()
        {
            GameEvents.OnLoadAmmo += LoadAmmo;
        }

        private void OnDisable()
        {
            GameEvents.OnLoadAmmo -= LoadAmmo;
        }
    }
}
