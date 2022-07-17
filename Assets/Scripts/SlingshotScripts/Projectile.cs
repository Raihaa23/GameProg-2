using System;
using Data.Ammo;
using Data.Player;
using Events;
using Interfaces;
using ManagersScripts;
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

        private void OnCollisionEnter2D(Collision2D other) //projectile collision
        {
            if (PlayerTurnManager.Instance.isProjectileReleased != true) return;
            if (other.gameObject.CompareTag(playerData.enemyDestructible))
            {
                var impactForce = other.relativeVelocity.magnitude;
                var enemyGameObj = other.gameObject;
                var enemyScript = enemyGameObj.GetComponent<IDamageable>();
                enemyScript?.Damage(Mathf.Round(ammoData.damageMultiplier * impactForce));
            }
            MatchEvents.OnCountToEndMethod();
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