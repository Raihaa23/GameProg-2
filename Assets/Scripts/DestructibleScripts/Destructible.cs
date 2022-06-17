using Data;
using Data.Destructibles;
using Data.Player;
using Events;
using Interfaces;
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
            Debug.Log(damageAmount);
            GameEvents.OnCalculateHpMethod();
            if (_currentHealth <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}