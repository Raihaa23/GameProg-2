using Data.Player;
using ManagersScripts;
using UnityEngine;


namespace SlingshotScripts
{
    public class Slingshot : MonoBehaviour
    {
        [SerializeField] protected SlingshotInputHandler inputHandler;
        [SerializeField] protected SlingshotMovement movement;
        [SerializeField] private PlayerData playerData;
        
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
       
        
    }
}
