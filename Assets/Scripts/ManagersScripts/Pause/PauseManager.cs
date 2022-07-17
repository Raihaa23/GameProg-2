using System;
using System.Runtime.CompilerServices;
using Events;
using SlingshotScripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace ManagersScripts.Pause
{
    public class PauseManager : MonoBehaviour
    {
        [SerializeField] private InputHandler inputHandler;
        [SerializeField] private PauseUI ui;
        [SerializeField] private GameObject invisibleWall;
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
            invisibleWall.SetActive(true);
            Time.timeScale = 0;
            ui.TogglePauseUI(true);
            _isPaused = true;
        }

        public void ResumeGame()
        {
            invisibleWall.SetActive(false);
            Time.timeScale = 1;
            ui.TogglePauseUI(false);
            _isPaused = false;
        }
    }
}