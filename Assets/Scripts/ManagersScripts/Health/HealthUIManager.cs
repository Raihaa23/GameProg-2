using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ManagersScripts.Health
{
    public class HealthUIManager : MonoBehaviour
    {
        // [SerializeField] private TextMeshProUGUI textDisplay;
        [SerializeField] private Slider slider;

        private void Start()
        {
            slider.value = 100f;
        }

        public void UpdateIntegrityUI(float integrityInPercent) // updates the health/integrity UI
        {
            slider.value = integrityInPercent;
            
        }
        
    }
}