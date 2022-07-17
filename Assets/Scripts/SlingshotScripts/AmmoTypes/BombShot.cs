using System;
using Events;
using Interfaces;
using UnityEngine;
using ManagersScripts;

namespace SlingshotScripts.AmmoTypes
{
    public class BombShot : Projectile
    {
        [SerializeField] private float fieldOfImpact;
        [SerializeField] private float force;

        [SerializeField] private LayerMask layerToHit;

        private void Update()
        {
            HandleAction();
        }

        private void HandleAction() // handles the action for this ammo type
        {
            if (!inputHandler.SpaceBarDown) return;
            if (PlayerTurnManager.Instance.isProjectileReleased && playerData.canDoAction)
            {
                Explode();
                playerData.canDoAction = false;
            }
        }

        private void Explode() // action
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<Animator>().SetTrigger(StringKeys.ExplosionAnim);
           Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, layerToHit);

           foreach (var obj in objects)
           {
               Vector2 direction = obj.transform.position - transform.position;
               obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
               var enemyScript = obj.GetComponent<IDamageable>();
               enemyScript?.Damage(ammoData.specialDamage);
           }
           MatchEvents.OnCountToEndMethod();
           
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, fieldOfImpact);
        }
        
    }
}