using System;
using Data.NPC;
using UnityEngine;
using Interfaces;

namespace NPCScripts
{
    public class Npc : MonoBehaviour, IDamageable
    {
        [SerializeField] private NpcData npcData;
        private float _currentHealth;

        private void Start()
        {
            _currentHealth = npcData.health;
        }

        public void Damage(float damageAmount) // Damages the Enemy NPC
        {
            _currentHealth -= damageAmount;
            if (_currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}