using UnityEngine;

namespace Events
{
    public class GameEvents : MonoBehaviour
    {
        public delegate void LoadAmmo();
        public static event LoadAmmo OnLoadAmmo;
        public static void OnLoadAmmoMethod()
        {
            if (OnLoadAmmo != null)
            {
                OnLoadAmmo();
            }
        }
        public delegate void CheckVictory();
        public static event CheckVictory OnCheckVictory;
        public static void OnVictoryMethod()
        {
            if (OnCheckVictory != null)
            {
                OnCheckVictory();
            }
        }
        
        public delegate void TimeUp();
        public static event TimeUp OnTimeUp;
        public static void OnTimeUpMethod()
        {
            if (OnTimeUp != null)
            {
                OnTimeUp();
            }
        }
        
        public delegate void DestroyBall();
        public static event DestroyBall OnDestroyBall;
        public static void OnDestroyBallMethod()
        {
            if (OnDestroyBall != null)
            {
                OnDestroyBall();
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