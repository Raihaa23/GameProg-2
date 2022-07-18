using System.Collections;
using Data.Ammo;
using Data.Player;
using Events;
using Interfaces;
using ManagersScripts;
using ManagersScripts.Audio;
using UnityEngine;

namespace SlingshotScripts.AmmoTypes
{
    public class SplitDebris : MonoBehaviour
    {
        [SerializeField] protected PlayerData playerData;
        [SerializeField] protected AmmoData ammoData;
        private bool isRunning = false;
        private bool canPlay = true;
        private void OnCollisionEnter2D(Collision2D other) //projectile collision
        {
            if (canPlay)
            {
                AudioManager.Instance.PlaySFX(StringKeys.SplitDebrisSfx);
                canPlay = false;
                StartCoroutine(SFXIntervalRate());
            }
            
            if (other.gameObject.CompareTag(playerData.enemyDestructible))
            {
                var impactForce = other.relativeVelocity.magnitude;
                var enemyGameObj = other.gameObject;
                var enemyScript = enemyGameObj.GetComponent<IDamageable>();
                enemyScript?.Damage(Mathf.Round(ammoData.damageMultiplier * impactForce));
            }
            MatchEvents.OnCountToEndMethod();
        }
        
        private IEnumerator SFXIntervalRate()
        {
            if (!isRunning)
            {
                isRunning = true;
                yield return new WaitForSeconds(0.5f);
                canPlay = true;
                isRunning = false;
            }
        }
        
        private void DestroyAmmo() //destroys projectile 
        {
            gameObject.SetActive(false);
        }
        private void OnEnable()
        {
            AmmoEvents.OnDestroyAmmo += DestroyAmmo;
        }

        private void OnDisable()
        {
            AmmoEvents.OnDestroyAmmo -= DestroyAmmo;
        }
    }
}