using System;
using UnityEngine;

namespace ManagersScripts.Pause
{
    public class PauseUI : MonoBehaviour
    {
        [SerializeField] private GameObject pauseUI;

        public void TogglePauseUI(bool boolCheck)
        {
            pauseUI.SetActive(boolCheck);
        }
    }
}