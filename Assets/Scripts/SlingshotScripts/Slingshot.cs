using Data;
using ManagersScripts;
using UnityEngine;
using Interfaces;
using Events;

namespace SlingshotScripts
{
    public class Slingshot : MonoBehaviour
    {
        [SerializeField] private SlingshotInputHandler inputHandler;
        [SerializeField] private SlingshotMovement movement;
        [SerializeField] private PlayerData playerData;
        private void Update()
        {
            CheckForBallReleaseAndRest();
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
            var enemyGameObj = other.gameObject;
            if (other.gameObject.CompareTag(playerData.enemyDestructible))
            {
                var enemyScript = enemyGameObj.GetComponent<IDamageable>();
                enemyScript?.Damage(50);
            }
        }

        private void CheckForBallReleaseAndRest() // Checks if the ball is release and rested to end turn
        {
            if (movement.BallIsSleeping() && PlayerTurnManager.Instance.isProjectileReleased)
            {
                GameEvents.OnDestroyBallMethod();
            }
        }

        private void DestroyBall() //destroys projectile 
        {
            playerData.equippedAmmo = null;
            PlayerTurnManager.Instance.EndTurn();
            Destroy(gameObject);
        }
        
        private void OnEnable()
        {
            GameEvents.OnDestroyBall += DestroyBall;
        }

        private void OnDisable()
        {
            GameEvents.OnDestroyBall -= DestroyBall;
        }
    }
}
