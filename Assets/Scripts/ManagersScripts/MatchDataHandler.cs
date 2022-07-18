using System;
using Data.Level;
using Data.Player;
using Events;
using UnityEngine;

namespace ManagersScripts
{
    public class MatchDataHandler : MonoBehaviour
    {
        [SerializeField] private PlayerData player1Data;
        [SerializeField] private PlayerData player2Data;
        private void ResetPlayerData() // Resets the Players' data
        {
            Time.timeScale = 1;
            player1Data.currentIntegrity = 0;
            player1Data.equippedAmmo = null;
            player1Data.totalIntegrity = 0;
            player1Data.canDoAction = true;
            player1Data.isKingDead = false;

            player2Data.currentIntegrity = 0;
            player2Data.equippedAmmo = null;
            player2Data.totalIntegrity = 0;
            player2Data.canDoAction = true;
            player2Data.isKingDead = false;
        }
        
        private void OnEnable()
        {
            DataEvents.OnResetPlayerData += ResetPlayerData;
        }

        private void OnDisable()
        {
            DataEvents.OnResetPlayerData -= ResetPlayerData;
        }
    }
}