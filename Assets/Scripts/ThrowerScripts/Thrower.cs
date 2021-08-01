using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    public delegate void AnimThrower();

    [SerializeField] private float _minThrowAngle;
    [SerializeField] private float _maxThrowAngle;

    [SerializeField] private float _minThrowSpeed;
    [SerializeField] private float _maxThrowSpeed;

    [SerializeField] private float _timeBetweenThrows;
    //[SerializeField] private Rock _rock;

    public event AnimThrower ThrowAnimation;

    private Vector3 _initialVelocity;


    private void Start()
    {
        StartCoroutine("StartThrowAnimation");
    }

    private IEnumerator StartThrowAnimation()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeBetweenThrows);

            _initialVelocity = CalculateVelocity();

            ThrowAnimation?.Invoke();            
        }
    }

    //public void ThrowRock()
    //{
    //    Rock rock = Instantiate(_rock, transform.position, Quaternion.identity);

    //    rock.Velocity = _initialVelocity;

    //    PhysicsHandler.Instance.AddObject(rock);
    //}

    private Vector3 CalculateVelocity()
    {
        float angle = Random.Range(_minThrowAngle, _maxThrowAngle);
        float launchSpeed = Random.Range(_minThrowSpeed, _maxThrowSpeed);//Velocity Module

        float cosAngle = Mathf.Cos(angle * Mathf.Deg2Rad);
        float sinAngle = Mathf.Sin(angle * Mathf.Deg2Rad);

        //Debug.Log(cosAngle);
        //Debug.Log(sinAngle);

        float velX = cosAngle * launchSpeed;
        float velY = sinAngle * launchSpeed;

        //Debug.Log(velX);
        //Debug.Log(velY);

        Vector3 velocity = new Vector3(velX, velY);

        //Debug.Log(velocity);

        return velocity;
    }
}