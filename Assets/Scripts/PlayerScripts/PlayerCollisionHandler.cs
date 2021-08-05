using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public delegate void CoinCollision();

    public event CoinCollision UpdateCoinCount;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("Colisión detectada");

        Debug.Log(hit.collider.attachedRigidbody.position);

        if (hit.gameObject.CompareTag("Coin"))
        {
            UpdateCoinCount?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            UpdateCoinCount?.Invoke();
        }
    }
}
