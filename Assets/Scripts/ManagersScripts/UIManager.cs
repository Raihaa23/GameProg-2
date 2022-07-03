using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public float backgroundScrollSpeed = 1f;

    private void Awake()
    {
        //Sets object to an instance when no instance is assigned otherwise if another instance is already assigned destroy the object
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
}


