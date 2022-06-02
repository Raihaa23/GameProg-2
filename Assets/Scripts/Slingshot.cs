using System.Collections;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [SerializeField] private SlingshotInputHandler inputHandler;
    [SerializeField] private SlingshotMovement movement;
    void Update()
    {
        HandleShot();
    }

    private void HandleShot()
    {
        // Check for mouse input
        if (inputHandler.MouseInputDown)
        {
           movement.CheckForBall();
        }

        if (inputHandler.MouseInput)
        {
           movement.CheckForBallDrag();
        }

        if (inputHandler.MouseInputUp)
        {
            movement.CheckForBallRelease();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine(DestroyBall());
    }
    
    private IEnumerator DestroyBall()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
