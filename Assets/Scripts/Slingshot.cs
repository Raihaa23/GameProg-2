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

    private void HandleShot()//Checks for mouse inputs
    {
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
    private void OnCollisionEnter2D(Collision2D other)// projectile collision
    {
        StartCoroutine(DestroyBall());
    }
    
    private IEnumerator DestroyBall()//destroys projectile
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
