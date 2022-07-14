using System;
using ManagersScripts.Audio;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            AudioManager.Instance.PlaySFX(StringKeys.TestSfx);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            AudioManager.Instance.PlayBGM(StringKeys.TestBGM);
        }
    }
}