using System;
using UnityEngine;

namespace ManagersScripts.Pause
{
    public class PauseInputHandler : MonoBehaviour
    {
        public bool EscapeDown { get; private set;}

        private void Update()
        {
            EscapeDown = CheckEscapeDown();
        }

        
        private bool CheckEscapeDown() //returns input upon button click
        {
            return Input.GetKeyDown(KeyCode.Escape);
        }
    }
}