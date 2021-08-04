using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public delegate void AnimPlayer(float speed, float flip);
    public event AnimPlayer RunAnimation;

    [SerializeField] private float _speed = 1.0f;

    [SerializeField] private JoystickInput _joystick;

    [SerializeField] private Rigidbody2D _rb;

    private Vector2 _dir;

    private void Update()
    {
        if (_joystick.GetAxisHorizontal() != 0)
        {
            _dir = new Vector2(_joystick.GetAxisHorizontal(), 0);

            RunAnimation?.Invoke(Mathf.Abs(_joystick.GetAxisHorizontal()), _joystick.GetAxisHorizontal());//Absolute value to avoid "-1" case. The second value is for the Flip Method; "-1" means left.
        }
    }

    private void FixedUpdate()
    {
        _rb.AddForce(_dir * _speed);
    }
}

    //// Update is called once per frame
    //void Update()
    //{
    //    GetInput();
    //    MoveHero();
    //}

    //private void MoveHero()
    //{
    //    transform.Translate( Vector2.right * _horizontal * _speed * Time.deltaTime);
    //}

    //private void GetInput()
    //{
    //    _horizontal = Input.GetAxis("Horizontal");

    //    RunAnimation?.Invoke(Mathf.Abs(_horizontal), _horizontal);//Absolute value to avoid "-1" case. The second value is for the Flip Method; "-1" means left.
    //}