using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _lifespan = 20f;

    private void Update()
    {
        ReduceCoinLife();
    }

    private void ReduceCoinLife()
    {
        _lifespan -= Time.deltaTime;

        if (_lifespan <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
