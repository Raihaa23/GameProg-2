using UnityEngine;

namespace Data.Level
{
    [CreateAssetMenu(fileName = "newLevelData", menuName = "Data/Level Data/Base Data", order = 0)]
    public class LevelData : ScriptableObject
    {
        public float timerChoice;
        public string levelChoice;
    }
}