using UnityEngine;

namespace ManagersScripts
{
    public class InputHandler : MonoBehaviour
    {
        public bool MouseInputDown { get; private set;}
        public bool MouseInput { get; private set; }
        public bool MouseInputUp { get; private set; }
        
        public bool SpaceBarDown { get; private set; }
        
        public bool EscapeDown { get; private set;}

        private void Update()
        {
            MouseInputDown = CheckMouseInputDown();
            MouseInput = CheckMouseInput();
            MouseInputUp = CheckMouseInputUp();
            SpaceBarDown = CheckSpaceBarDown();
            EscapeDown = CheckEscapeDown();
        }

        private bool CheckMouseInputDown() //returns input upon button click
        {
            return Input.GetMouseButtonDown(0);
        }
        private bool CheckMouseInput() //returns input while holding the button
        {
            return Input.GetMouseButton(0);
        }
        private bool CheckMouseInputUp() //returns input upon button release
        {
            return Input.GetMouseButtonUp(0);
        }

        private bool CheckSpaceBarDown() // returns input when space bar is pressed
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
        private bool CheckEscapeDown() //returns input upon button click
        {
            return Input.GetKeyDown(KeyCode.Escape);
        }
    }
}
