using Events;
using ManagersScripts;
using UnityEngine;

namespace SlingshotScripts.AmmoTypes
{
    public class SingleStone : Slingshot
    {
        protected override void Update()
        {
            HandleAction();
            base.Update();
        }
        
        private void HandleAction()
        {
            if (!inputHandler.SpaceBarDown) return;
            if (PlayerTurnManager.Instance.isProjectileReleased && playerData.canDoAction)
            {
                Debug.Log("Singlestone Action");
                playerData.canDoAction = false;
            }
        }
        
    }
}