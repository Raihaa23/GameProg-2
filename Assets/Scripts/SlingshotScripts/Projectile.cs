using System;
using System.Collections;
using Data.Ammo;
using Data.Player;
using Events;
using Interfaces;
using ManagersScripts;
using ManagersScripts.Audio;
using UnityEngine;
using UnityEngine.UI;

namespace SlingshotScripts
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] protected InputHandler inputHandler;
        [SerializeField] protected AmmoData ammoData;
        [SerializeField] protected PlayerData playerData;
        public string ammoName;
        public int totalAmmo;
        private bool isRunning = false;
        private bool canPlay = true;

        private void OnCollisionEnter2D(Collision2D other) //projectile collision
        {
            if (PlayerTurnManager.Instance.isProjectileReleased != true) return;
            
            if (canPlay)
            {
                AudioManager.Instance.PlaySFX(StringKeys.ImpactSfx);
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
        private void UnfreezeConstraints()
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
        private void ReduceAmmo() // reduces the ammo count in this script which will be passed on the ammo manager later
        {
            totalAmmo--;
        }
        private void DestroyAmmo() //destroys projectile 
        {
            gameObject.SetActive(false);
        }
        private void OnEnable()
        {
            AmmoEvents.OnDestroyAmmo += DestroyAmmo;
            AmmoEvents.OnReduceAmmo += ReduceAmmo;
            AmmoEvents.OnUnfreezeConstraints += UnfreezeConstraints;
            playerData.canDoAction = true;
        }

        private void OnDisable()
        {
            AmmoEvents.OnDestroyAmmo -= DestroyAmmo;
            AmmoEvents.OnReduceAmmo -= ReduceAmmo;
            AmmoEvents.OnUnfreezeConstraints -= UnfreezeConstraints;
        }
    }
}