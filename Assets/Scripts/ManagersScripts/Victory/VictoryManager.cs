using Data.Player;
using Events;
using TMPro;
using UnityEngine;

namespace ManagersScripts.Victory
{
    public class VictoryManager : MonoBehaviour
    {
        [SerializeField] private VictoryUIManager victoryUI;
        [SerializeField] private PlayerData player1Data;
        [SerializeField] private PlayerData player2Data;

       

        private void CheckVictory() // Called to check if a player has reached 0 health
        {
            if (player1Data.currentIntegrity <= 0)
            {
                victoryUI.SetVictoryScreen("Player 2 Wins");
                Time.timeScale = 0;
            }
            else if (player2Data.currentIntegrity <= 0)
            {
                victoryUI.SetVictoryScreen("Player 1 Wins");
                Time.timeScale = 0;
            }
            
        }

        private void TimeUp() // Called if the Main Game Timer runs out
        {
            if (player1Data.currentIntegrity > player2Data.currentIntegrity)
            {
                victoryUI.SetVictoryScreen("Player 1 Wins");
                PlayerTurnManager.Instance.playerInTurnName = "Player2";
            }
            else if (player2Data.currentIntegrity > player1Data.currentIntegrity)
            {
                victoryUI.SetVictoryScreen("Player 2 Wins");
                PlayerTurnManager.Instance.playerInTurnName = "Player1";
            }
            else if (player1Data.currentIntegrity == player2Data.currentIntegrity)
            {
                victoryUI.SetVictoryScreen("TIE");
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
            MatchEvents.OnCheckVictory += CheckVictory;
            TimerEvents.OnTimeUp += TimeUp;
        }

        private void OnDisable()
        {
            MatchEvents.OnCheckVictory -= CheckVictory;
            TimerEvents.OnTimeUp -= TimeUp;
        }
    }
}