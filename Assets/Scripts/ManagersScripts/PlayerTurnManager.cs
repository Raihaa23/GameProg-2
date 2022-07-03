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
            DataEvents.OnResetPlayerDataMethod();
        }

        public void EndTurn() // Ends player turn after projectile is destroyed
        {
            MatchEvents.OnVictoryMethod();
            TimerEvents.OnResetTurnTimerMethod();

            if (playerInTurnName == "Player1")
            {
                playerInTurnName = "Player2";
                
                
            }
            else if (playerInTurnName == "Player2")
            {
                playerInTurnName = "Player1";
                
                
            }
            UIEvents.OnToggleAmmoTextMethod();
            UIEvents.OnToggleAmmoButtonMethod();
            CameraEvents.OnToggleCameraMethod();
            AmmoEvents.OnLoadAmmoMethod();
        }

        
    }
}