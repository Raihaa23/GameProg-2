using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotInputHandler : MonoBehaviour
{
    public bool MouseInputDown { get; private set;}
    public bool MouseInput { get; private set; }
    public bool MouseInputUp { get; private set; }

    private void Update()
    {
        MouseInputDown = CheckMouseInputDown();
        MouseInput = CheckMouseInput();
        MouseInputUp = CheckMouseInputUp();
    }

    private bool CheckMouseInputDown()
    {
        return Input.GetMouseButtonDown(0);
    }
    private bool CheckMouseInput()
    {
        return Input.GetMouseButton(0);
    }
    private bool CheckMouseInputUp()
    {
        return Input.GetMouseButtonUp(0);
    }
}
