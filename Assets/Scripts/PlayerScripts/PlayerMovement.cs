using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public delegate void AnimPlayer(float speed, float flip);
    public event AnimPlayer RunAnimation;

    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _errorMargin = 20f;

    [SerializeField] private Vector2 _horizontalGesture = new Vector2(100, 0);
    private Vector2 _nullVector = new Vector2(-10000, -10000);
    private Vector2 _startPosition;

    private float _horizontalMovement;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _startPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                MoveHero(touch);
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                _startPosition = _nullVector;
            }

            RunAnimation?.Invoke(Mathf.Abs(_horizontalMovement), _horizontalMovement);//Absolute value to avoid "-1" case. The second value is for the Flip Method; "-1" means left.
        }
    }

    private void MoveHero(Touch touch)
    {
        Vector2 deltaMovement = touch.position - _startPosition;//Con esto sabemos cuanto se movió 

        if (CheckGesture(_horizontalGesture, deltaMovement))
        {
            _rb.AddForce(Vector2.right * _horizontalMovement * _speed);
        }
    }

    private bool CheckGesture(Vector2 gesture, Vector2 deltaMovement)
    {
        return ((gesture - deltaMovement).magnitude <= _errorMargin);
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