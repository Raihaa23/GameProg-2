using Events;
using ManagersScripts;
using UnityEngine;

namespace SlingshotScripts.AmmoTypes
{
    public class SingleStone : Projectile
    {
        private void Update()
        {
            HandleAction();
        }
        
        private void HandleAction() // handles the action for this ammo type
        {
            if (!inputHandler.SpaceBarDown) return;
            if (PlayerTurnManager.Instance.isProjectileReleased && playerData.canDoAction)
            {
                playerData.canDoAction = false;
            }
        }
        
    }
}