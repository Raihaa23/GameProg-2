using System;
using ManagersScripts.Audio;
using UnityEngine;
using UnityEngine.UI;

namespace BtnListeners
{
    public class ButtonScript : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(PlayBtnSfx);
        }

        private void PlayBtnSfx()
        {
            AudioManager.Instance.PlaySFX(StringKeys.ButtonSfx);
        }
    }
}