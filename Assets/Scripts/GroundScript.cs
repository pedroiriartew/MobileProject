using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            Rock rock = collision.gameObject.GetComponent<Rock>();

            rock.getRigidBody().velocity = Vector2.zero;//Setear la velocidad en 0

            rock.DestroyRock();
        }
    }

}
