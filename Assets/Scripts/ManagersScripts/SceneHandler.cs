using Data.Level;
using UnityEngine;
using Events;
using UnityEngine.SceneManagement;

namespace ManagersScripts
{
    public class SceneHandler : MonoBehaviour
    {
        [SerializeField] private LevelData levelData;
        public void PlayAgain() // Play the same level again
        {
            DataEvents.OnResetPlayerDataMethod();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void ReturnToMainMenu() // Return to Main Menu
        {
            DataEvents.OnResetPlayerDataMethod();
            PlayerTurnManager.Instance.playerInTurnName = null;
            SceneManager.LoadScene("MainMenu");
        }
        public void StartLevel()
        {
            SceneManager.LoadScene(levelData.levelChoice);
            AmmoEvents.OnLoadAmmoMethod();
        }
    }
}