using Data.Ammo;
using Data.Player;
using Events;
using Interfaces;
using ManagersScripts;
using UnityEngine;

namespace SlingshotScripts.AmmoTypes
{
    public class SplitDebris : MonoBehaviour
    {
        [SerializeField] protected PlayerData playerData;
        [SerializeField] protected AmmoData ammoData;
        private void OnCollisionEnter2D(Collision2D other) //projectile collision
        {
            
            if (other.gameObject.CompareTag(playerData.enemyDestructible))
            {
                var impactForce = other.relativeVelocity.magnitude;
                var enemyGameObj = other.gameObject;
                var enemyScript = enemyGameObj.GetComponent<IDamageable>();
                enemyScript?.Damage(ammoData.damageMultiplier * impactForce);
            }
            GameEvents.OnCountToEndMethod();
        }
        
        private void DestroyAmmo() //destroys projectile 
        {
            gameObject.SetActive(false);
        }
        private void OnEnable()
        {
            GameEvents.OnDestroyAmmo += DestroyAmmo;
        }

        private void OnDisable()
        {
            GameEvents.OnDestroyAmmo -= DestroyAmmo;
        }
    }
}