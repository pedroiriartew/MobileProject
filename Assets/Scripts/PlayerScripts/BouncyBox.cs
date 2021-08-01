using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBox : MonoBehaviour
{
    //[SerializeField] private float _verticalBouncinessFactor = 1f;
    //private const float _Ninety = 90f;

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Rock"))
    //    {
    //        Rock rock = collision.gameObject.GetComponent<Rock>();

    //        Vector3 newVelocity = GetNewVelocity(rock);

    //        Debug.Log(newVelocity);

    //        rock.Velocity = newVelocity;
    //        rock.Position += rock.Velocity;
    //        rock.transform.position += rock.Position;
    //        //rock.transform.position += rock.Velocity;
    //    }
    //}

    //private Vector3 GetNewVelocity(Rock rock)//new Vector3(0f, _Ninety)
    //{
    //    float angle = Vector3.Angle(transform.position, rock.Velocity);

    //    Debug.Log(angle);

    //    float xValue = Mathf.Sin(angle) * rock.Velocity.x;
    //    float yValue = Mathf.Cos(angle) * rock.Velocity.y;

    //    Vector3 newVelocity = new Vector3(xValue, yValue * (1 / _verticalBouncinessFactor));

    //    return newVelocity;
    //}
}
