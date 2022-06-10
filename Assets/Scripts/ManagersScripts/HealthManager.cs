using System;
using System.Globalization;
using Data;
using TMPro;
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

        private void Update()
        {
         CalculateIntegrityRate();   
        }

        private void CalculateIntegrityRate() // Calculates the total integrity of the player into percent then prints to text
        {
            _integrityInPercent = playerData.currentIntegrity / playerData.totalIntegrity;
            _integrityInPercent *= 100f;
            slider.value = _integrityInPercent;
            textDisplay.text = _integrityInPercent.ToString("f2") + "%";
        }
    }
}