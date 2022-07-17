using System;
using Data.Level;
using UnityEngine;

namespace ManagersScripts.Audio
{
    public class BGMCaller : MonoBehaviour
    {
        [SerializeField] private LevelData levelData;
        private void Start()
        {
            AudioManager.Instance.PlayIntroBGM(levelData.levelIntroBGM);
            AudioManager.Instance.PlayAmbient(levelData.levelAmbientBGM);
        }
    }
}