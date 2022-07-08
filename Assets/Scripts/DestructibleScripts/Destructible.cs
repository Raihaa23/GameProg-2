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
            _currentHealth -= damageAmount;
            if (_currentHealth <0)
            {
                damageAmount += _currentHealth;
            }
            playerData.currentIntegrity -= damageAmount;
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
                   Damage(impactForce * destructibleData.damageMultiplier);
                }
            }
        }
        
    }
}