using System;
using UnityEngine;

namespace ManagersScripts.Audio
{
    public class MainMenuBGMCaller : MonoBehaviour
    {
        private void Start()
        {
            AudioManager.Instance.PlayBGM(StringKeys.MainMenuBGM);
        }
    }
}