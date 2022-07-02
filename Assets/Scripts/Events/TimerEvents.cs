using UnityEngine;

namespace Events
{
    public class TimerEvents : MonoBehaviour
    { // EVENTS FOR MATCH AND TURN TIMERS
        public delegate void TimeUp();
        public static event TimeUp OnTimeUp;
        public static void OnTimeUpMethod()
        {
            if (OnTimeUp != null)
            {
                OnTimeUp();
            }
        }
        
        public delegate void PauseTurnTimer();
        public static event PauseTurnTimer OnPauseTurnTimer;
        public static void OnPauseTurnTimerMethod()
        {
            if (OnPauseTurnTimer != null)
            {
                OnPauseTurnTimer();
            }
        }
        
        public delegate void ResetTurnTimer();
        public static event ResetTurnTimer OnResetTurnTimer;
        public static void OnResetTurnTimerMethod()
        {
            if (OnResetTurnTimer != null)
            {
                OnResetTurnTimer();
            }
        }
    }
}