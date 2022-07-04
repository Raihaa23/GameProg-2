using System;
using System.Runtime.CompilerServices;
using Events;
using SlingshotScripts;
using UnityEngine;

namespace ManagersScripts.Pause
{
    public class PauseManager : MonoBehaviour
    {
        [SerializeField] private PauseInputHandler inputHandler;
        [SerializeField] private PauseUI ui;
        private bool _isPaused;

        private void Start()
        {
            _isPaused = false;
        }

        private void Update()
        {
            HandlePause();
        }

        private void HandlePause()
        {
            if (!inputHandler.EscapeDown) return;
            switch (_isPaused)
            {
                case false:
                    PauseGame();
                    break;
                    
                case true:
                    ResumeGame();
                    break;
            }
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
            ui.TogglePauseUI(true);
            _isPaused = true;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
            ui.TogglePauseUI(false);
            _isPaused = false;
        }
    }
}