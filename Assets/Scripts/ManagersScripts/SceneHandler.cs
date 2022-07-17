using Data.Level;
using UnityEngine;
using Events;
using ManagersScripts.Audio;
using UnityEngine.SceneManagement;

namespace ManagersScripts
{
    public class SceneHandler : MonoBehaviour
    {
        [SerializeField] private LevelData levelData;
        public void PlayAgain() // Play the same level again
        {
            AudioManager.Instance.StopAllMusic();
            DataEvents.OnResetPlayerDataMethod();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void ReturnToMainMenu() // Return to Main Menu
        {
            AudioManager.Instance.StopAllMusic();
            DataEvents.OnResetPlayerDataMethod();
            PlayerTurnManager.Instance.playerInTurnName = null;
            SceneManager.LoadScene("MainMenu");
        }
        public void StartLevel()
        {
            AudioManager.Instance.StopAllMusic();
            SceneManager.LoadScene(levelData.levelChoice);
            AmmoEvents.OnLoadAmmoMethod();
        }
    }
}