using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public delegate void CoinCollision();

    private float _negativeValueBound = -4.9f;//This is an offset near the position of the hydrant where the thrower is.
    private float _positiveValueBound = 16.7f;//This is an offset near the position of the wheels on the right.

    public event CoinCollision Coin;

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            
            if (collision.gameObject.name == "Hydrant")
            {
                transform.position = new Vector3(_negativeValueBound, transform.position.y, transform.position.z);
            }

            if (collision.gameObject.name == "Objective")
            {
                transform.position = new Vector3(_positiveValueBound, transform.position.y, transform.position.z);
            }
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            Coin?.Invoke();
        }
    }
}
