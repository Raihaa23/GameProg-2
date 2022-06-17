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
            var enemyGameObj = other.gameObject;
            if (other.gameObject.CompareTag(playerData.enemyDestructible))
            {
                var enemyScript = enemyGameObj.GetComponent<IDamageable>();
                enemyScript?.Damage(ammoData.baseDamage);
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