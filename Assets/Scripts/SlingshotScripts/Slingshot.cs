using System.Collections;
using System.Runtime.CompilerServices;
using Data;
using Data.Ammo;
using Data.Player;
using ManagersScripts;
using UnityEngine;
using Interfaces;
using Events;
using Unity.VisualScripting;

namespace SlingshotScripts
{
    public class Slingshot : MonoBehaviour
    {
        [SerializeField] protected SlingshotInputHandler inputHandler;
        [SerializeField] protected SlingshotMovement movement;
        [SerializeField] protected PlayerData playerData;
        [SerializeField] protected AmmoData ammoData;
        public int totalAmmo;
        protected virtual void Update()
        {
            HandleShot();
        }

        private void HandleShot() //Checks for mouse inputs
        {
            if (playerData.playerName != PlayerTurnManager.Instance.playerInTurnName) return;
            if (inputHandler.MouseInputDown)
            {
                movement.CheckForBall();
            }

            if (inputHandler.MouseInput)
            {
                movement.CheckForBallDrag();
            }

            if (inputHandler.MouseInputUp)
            {
                movement.CheckForBallRelease();
            }
        }
        private void OnCollisionEnter2D(Collision2D other) //projectile collision
        {
            if (PlayerTurnManager.Instance.isProjectileReleased != true) return;
            if (other.gameObject.CompareTag(playerData.enemyDestructible))
            {
                var impactForce = other.relativeVelocity.magnitude;
                var enemyGameObj = other.gameObject;
                var enemyScript = enemyGameObj.GetComponent<IDamageable>();
                enemyScript?.Damage(ammoData.damageMultiplier * impactForce);
            }
            GameEvents.OnCountToEndMethod();
        }
        private void ReduceAmmo()
        {
            totalAmmo--;
        }
        private void DestroyAmmo() //destroys projectile 
        {
            gameObject.SetActive(false);
        }
        private void OnEnable()
        {
            GameEvents.OnDestroyAmmo += DestroyAmmo;
            GameEvents.OnReduceAmmo += ReduceAmmo;
            playerData.canDoAction = true;
        }

        private void OnDisable()
        {
            GameEvents.OnDestroyAmmo -= DestroyAmmo;
            GameEvents.OnReduceAmmo -= ReduceAmmo;
        }
        
    }
}
