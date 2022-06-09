using UnityEngine;
using Events;
using UnityEngine.SceneManagement;

namespace ManagersScripts
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private string nextStage;
        public void StartWithPlayer1() // Starts the game with Player 1's turn 
        {
            PlayerTurnManager.Instance.playerInTurnName = "Player1";
            SceneManager.LoadScene(nextStage);
            GameEvents.OnLoadAmmoMethod();
        }
    
        public void StartWithPlayer2() // Starts the game with Player 2's turn 
        {
            PlayerTurnManager.Instance.playerInTurnName = "Player2";
            SceneManager.LoadScene(nextStage);
            GameEvents.OnLoadAmmoMethod();
        }
        
        public void PlayAgain() // Play the same level again
        {
            PlayerTurnManager.Instance.ResetPlayerData();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        public void ReturnToMainMenu() // Return to Main Menu
        {
            PlayerTurnManager.Instance.ResetPlayerData();
            PlayerTurnManager.Instance.playerInTurnName = null;
            SceneManager.LoadScene("MainMenu");
        }
    }
}