using System.Collections;
using Data;
using ManagersScripts;
using UnityEngine;
using Interfaces;

namespace SlingshotScripts
{
    public class Slingshot : MonoBehaviour
    {
        [SerializeField] private SlingshotInputHandler inputHandler;
        [SerializeField] private SlingshotMovement movement;
        [SerializeField] private PlayerData _playerData;

        private void Update()
        {
            HandleShot();
        }

        private void HandleShot() //Checks for mouse inputs
        {
            if (_playerData.playerName != PlayerTurnManager.Instance.playerInTurnName) return;
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
            var enemyGameObj = other.gameObject;
            if (other.gameObject.CompareTag(_playerData.enemyNpc))
            {
                var enemyScript = enemyGameObj.GetComponent<IDamageable>();
                enemyScript?.Damage(50);
            }
            StartCoroutine(DestroyBall());
        }
    
        private IEnumerator DestroyBall() //destroys projectile
        {
            yield return new WaitForSeconds(2);
            PlayerTurnManager.Instance.EndTurn();
            Destroy(gameObject);
        }
    }
}
