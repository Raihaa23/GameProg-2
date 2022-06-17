using System.Diagnostics;
using Data;
using Data.Player;
using UnityEngine;
using Events;
using TMPro;


namespace ManagersScripts
{
    public class VictoryManager : MonoBehaviour
    {
        [SerializeField] private PlayerData player1Data;
        [SerializeField] private PlayerData player2Data;

        [SerializeField] private GameObject victoryScreen;
        [SerializeField] private TextMeshProUGUI victoryMessage;

        private void CheckVictory() // Called to check if a player has reached 0 health
        {
            if (player1Data.currentIntegrity <= 0)
            {
                victoryScreen.SetActive(true);
                victoryMessage.text = "Player 2 Wins";
                Time.timeScale = 0;
            }
            else if (player2Data.currentIntegrity <= 0)
            {
                victoryScreen.SetActive(true);
                victoryMessage.text = "Player 1 Wins";
                Time.timeScale = 0;
            }
            
        }

        private void TimeUp() // Called if the Main Game Timer runs out
        {
            if (player1Data.currentIntegrity > player2Data.currentIntegrity)
            {
                victoryScreen.SetActive(true);
                victoryMessage.text = "Player 1 Wins";
                PlayerTurnManager.Instance.playerInTurnName = "Player2";
            }
            else if (player2Data.currentIntegrity > player1Data.currentIntegrity)
            {
                victoryScreen.SetActive(true);
                victoryMessage.text = "Player 2 Wins";
                PlayerTurnManager.Instance.playerInTurnName = "Player1";
            }
            else if (player1Data.currentIntegrity == player2Data.currentIntegrity)
            {
                victoryScreen.SetActive(true);
                victoryMessage.text = "TIE";
                switch (PlayerTurnManager.Instance.playerInTurnName)
                {
                    case "Player1":
                        PlayerTurnManager.Instance.playerInTurnName = "Player2";
                        break;
                    
                    case "Player2":
                        PlayerTurnManager.Instance.playerInTurnName = "Player1";
                        break;
                }
            }
            Time.timeScale = 0;
        }
        

        private void OnEnable()
        {
            GameEvents.OnCheckVictory += CheckVictory;
            GameEvents.OnTimeUp += TimeUp;
        }

        private void OnDisable()
        {
            GameEvents.OnCheckVictory -= CheckVictory;
            GameEvents.OnTimeUp -= TimeUp;
        }
    }
}