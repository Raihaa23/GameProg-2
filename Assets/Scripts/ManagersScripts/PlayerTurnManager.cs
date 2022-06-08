using System;
using System.Security;
using Data;
using Events;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        [SerializeField] private PlayerData player1Data;
        [SerializeField] private PlayerData player2Data;

        [SerializeField] private string nextStage;

        private void Start()
        {
         ResetPlayerData();   
        }

        public void ResetPlayerData() // Resets the Players' data
        {
            player1Data.currentIntegrity = 0;
            player1Data.equippedAmmo = null;
            player1Data.totalIntegrity = 0;

            player2Data.currentIntegrity = 0;
            player2Data.equippedAmmo = null;
            player2Data.totalIntegrity = 0;
        }

        public void EndTurn() // Ends player turn after projectile is destroyed
        {
            if (playerInTurnName == "Player1")
            {
                playerInTurnName = "Player2";
                GameEvents.OnLoadAmmoMethod();
            }
        
            else if (playerInTurnName == "Player2")
            {
                playerInTurnName = "Player1";
                GameEvents.OnLoadAmmoMethod();
            }
        }

        public void StartWithPlayer1() // Starts the game with Player 1's turn 
        {
            playerInTurnName = "Player1";
            SceneManager.LoadScene(nextStage);
            GameEvents.OnLoadAmmoMethod();
        }
    
        public void StartWithPlayer2() // Starts the game with Player 2's turn 
        {
            playerInTurnName = "Player2";
            SceneManager.LoadScene(nextStage);
            GameEvents.OnLoadAmmoMethod();
        }
    }
}