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
        
        // public delegate void QueueNextTurn();
        // public static event QueueNextTurn OnQueueNextTurn;
        // public static void OnQueueNextTurnMethod()
        // {
        //     if (OnQueueNextTurn != null)
        //     {
        //         OnQueueNextTurn();
        //     }
        // }
        
        public delegate void DestroyAmmo();
        public static event DestroyAmmo OnDestroyAmmo;
        public static void OnDestroyAmmoMethod()
        {
            if (OnDestroyAmmo != null)
            {
                OnDestroyAmmo();
            }
        }
        
        public delegate void ToggleAmmoButton();
        public static event ToggleAmmoButton OnToggleAmmoButton;
        public static void OnToggleAmmoButtonMethod()
        {
            if (OnToggleAmmoButton != null)
            {
                OnToggleAmmoButton();
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
        
        public delegate void SetCamera(GameObject activeBall);
        public static event SetCamera OnSetCamera;
        public static void OnSetCameraMethod(GameObject activeBall)
        {
            if (OnSetCamera != null)
            {
                OnSetCamera(activeBall);
            }
        }
        
        public delegate void ToggleCamera();
        public static event ToggleCamera OnToggleCamera;
        public static void OnToggleCameraMethod()
        {
            if (OnToggleCamera != null)
            {
                OnToggleCamera();
            }
        }
        
        public delegate void CalculateHp();
        public static event CalculateHp OnCalculateHp;
        public static void OnCalculateHpMethod()
        {
            if (OnCalculateHp != null)
            {
                OnCalculateHp();
            }
        }
        
        public delegate void ReduceAmmo();
        public static event ReduceAmmo OnReduceAmmo;
        public static void OnReduceAmmoMethod()
        {
            if (OnReduceAmmo != null)
            {
                OnReduceAmmo();
            }
        }
        
        public delegate void CountToEnd();
        public static event CountToEnd OnCountToEnd;
        public static void OnCountToEndMethod()
        {
            if (OnCountToEnd != null)
            {
                OnCountToEnd();
            }
        }

    }
}