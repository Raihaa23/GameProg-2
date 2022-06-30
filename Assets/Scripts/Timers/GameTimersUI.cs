using TMPro;
using UnityEngine;

namespace Timers
{
    public class GameTimersUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI totalTimerTxt;
        [SerializeField] private TextMeshProUGUI turnTimerTxt;
        
        public void ConvertTotalTimer(float currentTotalTime) // Converts the Main Timer into Minutes:Seconds format
        {
            currentTotalTime += 1;
            float minutes = Mathf.FloorToInt(currentTotalTime / 60);
            float seconds = Mathf.FloorToInt(currentTotalTime % 60);
            totalTimerTxt.text = $"{minutes:00} : {seconds:00}";
        }
        
        public void ConvertTurnTimer(float currentTurnTime) // Converts the Turn Timer into Minutes:Seconds format
        {
            currentTurnTime += 1;
            float minutes = Mathf.FloorToInt(currentTurnTime / 60);
            float seconds = Mathf.FloorToInt(currentTurnTime % 60);
            turnTimerTxt.text = $"{minutes:00} : {seconds:00}";
        }
    }
}