using System.Collections;
using Events;
using ManagersScripts;
using TMPro;
using UnityEngine;

namespace Timers
{
    public class GameTimers : MonoBehaviour
    {
        [SerializeField] private float totalTimeLeft;
        [SerializeField] private float turnTimeLeft;
        private float _initialTurnTimeLeft;
        private bool _totalTimerOn;
        private bool _turnTimerOn;
        private bool _isRunning = false;

        [SerializeField] private TextMeshProUGUI totalTimerTxt;
        [SerializeField] private TextMeshProUGUI turnTimerTxt;

        private void Start()
        {
            _totalTimerOn = true;
            _turnTimerOn = true;
            _initialTurnTimeLeft = turnTimeLeft;
        }

        private void Update()
        {
            UpdateTotalTimer();
            UpdateTurnTimer();
        }

        private void UpdateTotalTimer() // updates the Main timer of the game
        {
            if (!_totalTimerOn) return;
            if (totalTimeLeft > 0)
            {
                totalTimeLeft -= Time.deltaTime;
                ConvertTotalTimer(totalTimeLeft);
            }
            else
            {
                totalTimeLeft = 0;
                _totalTimerOn = false;
                GameEvents.OnTimeUpMethod();
            }
        }
        
        private void UpdateTurnTimer() // updates the player's turn timer
        {
            if (!_turnTimerOn) return;
            if (turnTimeLeft > 0)
            {
                turnTimeLeft -= Time.deltaTime;
                ConvertTurnTimer(turnTimeLeft);
            }
            else
            {
                Debug.Log("Turn Times Up");
                GameEvents.OnToggleAmmoButtonMethod();
                GameEvents.OnDestroyAmmoMethod();
                PlayerTurnManager.Instance.EndTurn();
            }
        }
        
        private void CountToEnd()
        {
            StartCoroutine(Countdown());
        }

        private IEnumerator Countdown()
        {
            if (!_isRunning)
            {
                Debug.Log("initialize countdown");
                _isRunning = true;
                yield return new WaitForSeconds(5);
                Debug.Log("Next Turn");
                GameEvents.OnDestroyAmmoMethod();
                PlayerTurnManager.Instance.EndTurn();
                _isRunning = false;
            }
        }

        private void PauseTurnTimer()
        {
            _turnTimerOn = false;
        }

        private void ResetTurnTimer() // Resets the Turn Timer
        {
            turnTimeLeft = _initialTurnTimeLeft;
            _turnTimerOn = true;
        }
        
        private void ConvertTotalTimer(float currentTotalTime) // Converts the Main Timer into Minutes:Seconds format
        {
            currentTotalTime += 1;
            float minutes = Mathf.FloorToInt(currentTotalTime / 60);
            float seconds = Mathf.FloorToInt(currentTotalTime % 60);
            totalTimerTxt.text = $"{minutes:00} : {seconds:00}";
        }
        
        private void ConvertTurnTimer(float currentTurnTime) // Converts the Turn Timer into Minutes:Seconds format
        {
            currentTurnTime += 1;
            float minutes = Mathf.FloorToInt(currentTurnTime / 60);
            float seconds = Mathf.FloorToInt(currentTurnTime % 60);
            turnTimerTxt.text = $"{minutes:00} : {seconds:00}";
        }
        
        private void OnEnable()
        {
            GameEvents.OnResetTurnTimer += ResetTurnTimer;
            GameEvents.OnPauseTurnTimer += PauseTurnTimer;
            GameEvents.OnCountToEnd += CountToEnd;
        }

        private void OnDisable()
        {
            GameEvents.OnResetTurnTimer -= ResetTurnTimer;
            GameEvents.OnPauseTurnTimer -= PauseTurnTimer;
            GameEvents.OnCountToEnd -= CountToEnd;
        }
    }
}