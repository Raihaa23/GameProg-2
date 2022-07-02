using System.Collections;
using Data.Level;
using Events;
using ManagersScripts;
using TMPro;
using UnityEngine;

namespace Timers
{
    public class GameTimers : MonoBehaviour
    {
        [Header("Component References")]
        [SerializeField] private GameTimersUI timersUI;
        [SerializeField] private LevelData levelData;
        
        [Header("Timer variables")]
        private float _totalTimeLeft;
        [SerializeField] private float turnTimeLeft;
        private float _initialTurnTimeLeft;
        private bool _totalTimerOn;
        private bool _turnTimerOn;
        
        private void Start()
        {
            _totalTimerOn = true;
            _turnTimerOn = true;
            _initialTurnTimeLeft = turnTimeLeft;
            _totalTimeLeft = levelData.timerChoice;
        }

        private void Update()
        {
            UpdateTotalTimer();
            UpdateTurnTimer();
        }

        private void UpdateTotalTimer() // updates the Main timer of the game
        {
            if (!_totalTimerOn) return;
            if (_totalTimeLeft > 0)
            {
                _totalTimeLeft -= Time.deltaTime;
                timersUI.ConvertTotalTimer(_totalTimeLeft);
            }
            else
            {
                _totalTimeLeft = 0;
                _totalTimerOn = false;
                TimerEvents.OnTimeUpMethod();
            }
        }
        
        private void UpdateTurnTimer() // updates the player's turn timer
        {
            if (!_turnTimerOn) return;
            if (turnTimeLeft > 0)
            {
                turnTimeLeft -= Time.deltaTime;
                timersUI.ConvertTurnTimer(turnTimeLeft);
            }
            else
            {
                Debug.Log("Turn Times Up");
                UIEvents.OnToggleAmmoTextMethod();
                UIEvents.OnToggleAmmoButtonMethod();
                AmmoEvents.OnDestroyAmmoMethod();
                PlayerTurnManager.Instance.EndTurn();
            }
        }

        private void PauseTurnTimer() // pauses the turn timer
        {
            _turnTimerOn = false;
        }

        private void ResetTurnTimer() // Resets the Turn Timer
        {
            turnTimeLeft = _initialTurnTimeLeft;
            _turnTimerOn = true;
        }
        
        
        private void OnEnable()
        {
            TimerEvents.OnResetTurnTimer += ResetTurnTimer;
            TimerEvents.OnPauseTurnTimer += PauseTurnTimer;
            
        }

        private void OnDisable()
        {
            TimerEvents.OnResetTurnTimer -= ResetTurnTimer;
            TimerEvents.OnPauseTurnTimer -= PauseTurnTimer;
            
        }
    }
}