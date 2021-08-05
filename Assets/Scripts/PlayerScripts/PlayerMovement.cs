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

    [SerializeField] private CharacterController _characterController;

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (_joystick.GetAxisHorizontal() != 0)
        {
            Vector3 dir = new Vector3(_joystick.GetAxisHorizontal(), 0f, 0f);

            _characterController.Move(dir * _speed * Time.deltaTime);

            RunAnimation?.Invoke(Mathf.Abs(_joystick.GetAxisHorizontal()), _joystick.GetAxisHorizontal());//Absolute value to avoid "-1" case. The second value is for the Flip Method; "-1" means left.
        }

        //if (_joystick.GetAxisHorizontal() == 0)
        //{
        //    _dir = Vector3.zero;
        //}
    }
}