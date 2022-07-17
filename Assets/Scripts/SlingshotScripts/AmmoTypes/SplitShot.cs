using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Events;
using UnityEngine;
using ManagersScripts;
using ManagersScripts.Audio;
using Unity.VisualScripting;

namespace SlingshotScripts.AmmoTypes
{
    public class SplitShot : Projectile
    {
        [SerializeField] private List<GameObject> splitDebris = new List<GameObject>();
        [SerializeField] private List<GameObject> debriSpawnLoc = new List<GameObject>();
        [SerializeField] private float forceDirection;
        private int _index = 0;
        private float _xForceMultiplier = 60;
        private float _yForceMultiplier = 100;
        private void Update()
        {
            HandleAction();
        }
        
        private void HandleAction() // handles the action for this ammo type
        {
            if (!inputHandler.SpaceBarDown) return;
            if (PlayerTurnManager.Instance.isProjectileReleased && playerData.canDoAction)
            {
                SplitIntoDebris();
                playerData.canDoAction = false;
            }
        }

        private void SplitIntoDebris() // action
        {
            AudioManager.Instance.PlaySFX(StringKeys.SplitEffectSfx);
            GetComponent<CircleCollider2D>().enabled = false;
            foreach (var debris in splitDebris)
            {
                debris.transform.position = debriSpawnLoc[_index].transform.position;
                debris.SetActive(true);
                var rb = gameObject.GetComponent<Rigidbody2D>();
                var debrisRb = debris.GetComponent<Rigidbody2D>();
                if (rb.velocity.magnitude <= 10)
                {
                    _xForceMultiplier = 0;
                }
                debrisRb.AddForce(transform.right * rb.velocity.magnitude * _xForceMultiplier * forceDirection);
                debrisRb.AddForce(transform.up * -_yForceMultiplier);
                _xForceMultiplier -= 10;
                _yForceMultiplier += 100;
                _index++;
            }
            _index = 0;
            _xForceMultiplier = 60;
            _yForceMultiplier = 100;
            GetComponent<Animator>().SetTrigger(StringKeys.SplitAnim);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            CameraEvents.OnSetCameraMethod(splitDebris[1]);
        }
        
    }
}