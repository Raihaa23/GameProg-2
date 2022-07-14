using System;
using Data;
using Data.Destructibles;
using Data.Player;
using Events;
using Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace DestructibleScripts
{
    public class Destructible : MonoBehaviour, IDamageable
    {
        [SerializeField] private DestructibleData destructibleData;
        [SerializeField] private PlayerData playerData;
        [SerializeField] private float _currentHealth;

        private void Start()
        {
            _currentHealth = destructibleData.health;
            playerData.totalIntegrity += _currentHealth;
            playerData.currentIntegrity = playerData.totalIntegrity;
        }

        public void Damage(float damageAmount) // Damages the Enemy NPC
        {
            _currentHealth -= Mathf.Round(damageAmount);
            if (_currentHealth <0)
            {
                damageAmount += _currentHealth;
            }
            playerData.currentIntegrity -= Mathf.Clamp(damageAmount, 0, playerData.currentIntegrity);
            DestructibleEvents.OnCalculateHpMethod();
            if (_currentHealth <= 0)
            {
                gameObject.SetActive(false);
            }
        }

        private void OnCollisionEnter2D(Collision2D other) //projectile collision
        {
            if (!other.gameObject.layer.Equals(playerData.enemyAmmoLayer))
            {
                var impactForce = other.relativeVelocity.magnitude;
                if (impactForce >= 4)
                {
                   Damage(Mathf.Round(impactForce * destructibleData.damageMultiplier));
                }
            }
        }
        
    }
}