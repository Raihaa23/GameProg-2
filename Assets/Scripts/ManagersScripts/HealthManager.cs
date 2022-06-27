using System;
using System.Globalization;
using Data;
using Data.Player;
using Events;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace ManagersScripts
{
    public class HealthManager : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        [SerializeField] private TextMeshProUGUI textDisplay;
        
        private float _integrityInPercent;
        [SerializeField] private Slider slider;

        private void Start()
        {
            slider.value = 100f;
        }

        private void CalculateIntegrityRate() // Calculates the total integrity of the player into percent then prints to text
        {
            _integrityInPercent = playerData.currentIntegrity / playerData.totalIntegrity;
            _integrityInPercent *= 100f;
            slider.value = _integrityInPercent;
            textDisplay.text = _integrityInPercent.ToString("f2") + "%";
        }

        private void OnEnable()
        {
            GameEvents.OnCalculateHp += CalculateIntegrityRate;
        }

        private void OnDisable()
        {
            GameEvents.OnCalculateHp -= CalculateIntegrityRate;
        }
    }
}