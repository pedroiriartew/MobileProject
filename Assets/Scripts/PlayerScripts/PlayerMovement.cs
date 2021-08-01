using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public delegate void AnimPlayer(float speed, float flip);

    [SerializeField] private float _speed = 1.0f;

    private float _horizontal;

    public event AnimPlayer RunAnimation;

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MoveHero();
    }

    private void MoveHero()
    {
        transform.Translate( Vector2.right * _horizontal * _speed);
    }

    private void GetInput()
    {
        _horizontal = Input.GetAxis("Horizontal");

        RunAnimation?.Invoke(Mathf.Abs(_horizontal), _horizontal);//Absolute value to avoid -1. The second value is for the Flip Method;
    }
}
