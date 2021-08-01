using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public delegate void CoinCollision();

    public event CoinCollision Coin;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Coin?.Invoke();
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (collision.gameObject.name == "Hydrant")
            {
                Debug.Log("colisionando con el hidrante");
            }
            if (collision.gameObject.name == "Wheels")
            {
                Debug.Log("colisionando con las ruedas");
            }
        }
    }
}
