using System.Collections;
using DefaultNamespace;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [SerializeField] private SlingshotInputHandler inputHandler;
    [SerializeField] private SlingshotMovement movement;
    [SerializeField] private PlayerData _playerData;

    void Update()
    {
        HandleShot();
    }

    private void HandleShot()//Checks for mouse inputs
    {
        if (_playerData.playerName == PlayerTurnManager.Instance.playerInTurnName)
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
    }
    private void OnCollisionEnter2D(Collision2D other)// projectile collision
    {
        StartCoroutine(DestroyBall());
    }
    
    private IEnumerator DestroyBall()//destroys projectile
    {
        yield return new WaitForSeconds(2);
        PlayerTurnManager.Instance.EndTurn();
        Destroy(gameObject);
    }
}
