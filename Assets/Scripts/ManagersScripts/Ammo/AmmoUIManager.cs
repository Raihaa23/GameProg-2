using System;
using System.Collections.Generic;
using Data.Player;
using Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ManagersScripts.Ammo
{
    public class AmmoUIManager : MonoBehaviour
    {
        [Header("Component References")]
        [SerializeField] private PlayerData playerData;
        [Header("UI References")]
        [SerializeField] private GameObject ammoButtons;
        [SerializeField] private TextMeshProUGUI ammoToText;
        private void Start()
        {
            ToggleAmmoButtons();
            ToggleAmmoText();
        }
        private void ToggleAmmoButtons() // Toggles UI Ammo Buttons
        {
            if (playerData.playerName != PlayerTurnManager.Instance.playerInTurnName) return;
            switch (ammoButtons.activeSelf)
            {
                case true:
                    ammoButtons.SetActive(false);
                    break;
                case false:
                    ammoButtons.SetActive(true);
                    break;
            }
        }
        private void ToggleAmmoText() // Toggles UI Ammo text
        {
            if (playerData.playerName != PlayerTurnManager.Instance.playerInTurnName) return;
            switch (ammoToText.enabled)
            {
                case true:
                    ammoToText.enabled = false;
                    break;
                case false:
                    ammoToText.enabled = true;
                    break;
            }
        }
        public void UpdateAmmoText(int ammoLeft, string ammoName) // Updates the UI Ammo Text
        {
            ammoToText.text = ammoName + ":\n" + ammoLeft;
            if (ammoLeft <= -1)
            {
                ammoToText.text = ammoName + ":\n∞";
            }            
        }
        private void OnEnable()
        {
            UIEvents.OnToggleAmmoButton += ToggleAmmoButtons;
            UIEvents.OnToggleAmmoText += ToggleAmmoText;
        }
        private void OnDisable()
        {
            UIEvents.OnToggleAmmoButton -= ToggleAmmoButtons;
            UIEvents.OnToggleAmmoText -= ToggleAmmoText;
        }
    }
}