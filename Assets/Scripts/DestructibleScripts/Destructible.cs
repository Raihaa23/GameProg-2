using Data;
using Data.Destructibles;
using Interfaces;
using UnityEngine;

namespace DestructibleScripts
{
    public class Destructible : MonoBehaviour, IDamageable
    {
        [SerializeField] private DestructibleData destructibleData;
        [SerializeField] private PlayerData playerData;
        private float _currentHealth;

        private void Start()
        {
            _currentHealth = destructibleData.health;
            playerData.totalIntegrity += _currentHealth;
            playerData.currentIntegrity = playerData.totalIntegrity;
        }

        public void Damage(float damageAmount) // Damages the Enemy NPC
        {
            _currentHealth -= damageAmount;
            playerData.currentIntegrity -= damageAmount;
            if (_currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}