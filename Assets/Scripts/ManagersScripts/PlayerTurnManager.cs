using System;
using System.Collections;
using Data;
using Data.Player;
using Events;
using UnityEngine;


namespace ManagersScripts
{
    public class PlayerTurnManager : MonoBehaviour
    {
        #region Singleton

        private static PlayerTurnManager _instance;
        public static PlayerTurnManager Instance => _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                DontDestroyOnLoad(gameObject);
                _instance = this;
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
        #endregion

        public string playerInTurnName;
        public bool isProjectileReleased;

        private void Start()
        {
            GameEvents.OnResetPlayerDataMethod();
            // GameEvents.OnResetLevelDataMethod();
        }

        public void EndTurn() // Ends player turn after projectile is destroyed
        {
            GameEvents.OnVictoryMethod();
            GameEvents.OnResetTurnTimerMethod();

            if (playerInTurnName == "Player1")
            {
                playerInTurnName = "Player2";
                
                
            }
            else if (playerInTurnName == "Player2")
            {
                playerInTurnName = "Player1";
                
                
            }
            GameEvents.OnToggleAmmoTextMethod();
            GameEvents.OnToggleAmmoButtonMethod();
            GameEvents.OnToggleCameraMethod();
            GameEvents.OnLoadAmmoMethod();
        }

        
    }
}