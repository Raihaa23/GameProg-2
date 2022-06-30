using Data.Player;
using Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ManagersScripts.Health
{
    public class HealthManager : MonoBehaviour
    {
        [SerializeField] private HealthUIManager healthUI;
        [SerializeField] private PlayerData playerData;
        private float _integrityInPercent;

        private void CalculateIntegrityRate() // Calculates the total integrity of the player into percent then prints to text
        {
            _integrityInPercent = playerData.currentIntegrity / playerData.totalIntegrity;
            _integrityInPercent *= 100f;
            healthUI.UpdateIntegrityUI(_integrityInPercent);
        }

        private void OnEnable()
        {
            DestructibleEvents.OnCalculateHp += CalculateIntegrityRate;
        }

        private void OnDisable()
        {
            DestructibleEvents.OnCalculateHp -= CalculateIntegrityRate;
        }
    }
}