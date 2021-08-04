using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInput : MonoBehaviour
{
    [SerializeField] private RectTransform _stick;
    [SerializeField] private RectTransform _stickArea;

    private float _maxMovement;

    private void Awake()
    {
        _maxMovement = _stickArea.sizeDelta.x / 2;
    }

    private void StickMovement()
    {
        _stick.transform.position = Input.mousePosition;

        Vector3 stickDelta = _stick.position - _stickArea.position;

        if (stickDelta.magnitude > _maxMovement)
        {
            _stick.position = _stickArea.position + stickDelta.normalized * _maxMovement;
        }
    }

    public Vector3 GetAxises()
    {
        return (_stick.position - _stickArea.position) / _maxMovement;
    }
    public float GetAxisHorizontal()
    {
        return (_stick.position - _stickArea.position).x / _maxMovement;
    }
    public float GetAxisVertical()
    {
        return (_stick.position - _stickArea.position).y / _maxMovement;
    }

    public void OnMouseButtonUp()
    {
        _stick.localPosition = Vector3.zero;
    }

    public void OnMouseButtonDown()
    {
        StickMovement();
    }
}
