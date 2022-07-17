using System;
using System.Collections;
using System.Collections.Generic;
using Events;
using ManagersScripts;
using UnityEngine;

namespace Timers
{
    public class EndTurnEnumerator : MonoBehaviour
    {
        private bool _isRunning = false;
        
        private void CountToEnd() //  is called to enumerate the switch of turns
        {
            StartCoroutine(Countdown());
        }

        private IEnumerator Countdown()
        {
            if (!_isRunning)
            {
                _isRunning = true;
                yield return new WaitForSeconds(5);
                AmmoEvents.OnDestroyAmmoMethod();
                PlayerTurnManager.Instance.EndTurn();
                _isRunning = false;
            }
        }

        private void OnEnable()
        {
            MatchEvents.OnCountToEnd += CountToEnd;
        }

        private void OnDisable()
        {
            MatchEvents.OnCountToEnd -= CountToEnd;
        }
    }
}