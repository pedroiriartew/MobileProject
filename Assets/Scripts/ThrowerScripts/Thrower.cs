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
    [SerializeField] private Rock _rock;

    public event AnimThrower ThrowAnimation;

    private Vector3 _velocity;


    private void Start()
    {
        StartCoroutine("StartThrowAnimation");
    }

    private IEnumerator StartThrowAnimation()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeBetweenThrows);

            _velocity = CalculateVelocity();

            ThrowAnimation?.Invoke();            
        }
    }

    public void ThrowRock()
    {
        Rock rock = Instantiate(_rock, transform.position, Quaternion.identity);

        rock.getRigidBody().AddForce(_velocity);
    }

    private Vector3 CalculateVelocity()
    {
        float angle = Random.Range(_minThrowAngle, _maxThrowAngle);
        float force = Random.Range(_minThrowSpeed, _maxThrowSpeed);

        Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;

        Vector3 velocity = dir * force;

        return velocity;
    }
}