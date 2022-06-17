using System.Collections.Generic;
using Events;
using UnityEngine;
using ManagersScripts;
using Unity.VisualScripting;

namespace SlingshotScripts.AmmoTypes
{
    public class SplitShot : Slingshot
    {
        [SerializeField] private List<GameObject> splitDebris = new List<GameObject>();
        [SerializeField] private float forceDirection;
        private float _xForceMultiplier = 50;
        private float _yForceMultiplier = 100;
        protected override void Update()
        {
            HandleAction();
            Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity.magnitude);
            base.Update();
        }
        
        private void HandleAction()
        {
            if (!inputHandler.SpaceBarDown) return;
            if (PlayerTurnManager.Instance.isProjectileReleased && playerData.canDoAction)
            {
                SplitIntoDebris();
                playerData.canDoAction = false;
            }
        }

        private void SplitIntoDebris()
        {
            foreach (var debris in splitDebris)
            {
                Debug.Log("launch debris");
                debris.transform.position = gameObject.transform.position;
                debris.SetActive(true);
                var rb = gameObject.GetComponent<Rigidbody2D>();
                var debrisRb = debris.GetComponent<Rigidbody2D>();
                debrisRb.AddForce(transform.right * rb.velocity.magnitude * _xForceMultiplier * forceDirection);
                debrisRb.AddForce(transform.up * -_yForceMultiplier);
                _xForceMultiplier -= 10;
                _yForceMultiplier += 50;
            }
            _xForceMultiplier = 50;
            _yForceMultiplier = 100;
            GameEvents.OnSetCameraMethod(splitDebris[1]);
            gameObject.SetActive(false);
        }
        
    }
}