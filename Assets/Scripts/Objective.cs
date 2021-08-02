using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public delegate void RockCollision();

    public event RockCollision IsRockColliding;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            IsRockColliding?.Invoke();
            Rock rock = collision.gameObject.GetComponent<Rock>();
            rock.DestroyOnObjective();
        }

    }
}
