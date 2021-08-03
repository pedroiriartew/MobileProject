using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    public delegate void AnimThrower();

    [SerializeField] private AudioClip _clip;

    [SerializeField] private float _minThrowAngle;
    [SerializeField] private float _maxThrowAngle;

    [SerializeField] private float _minThrowSpeed;
    [SerializeField] private float _maxThrowSpeed;

    [SerializeField] private float _timeBetweenThrows;

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
        AudioManager.Instance.PlayClip(_clip, 1, false, AudioManager.ChannelType.Sfx);

        GameObject rock = PoolManager.Instance.GetPoolObject("Rock");
        rock.AddComponent<Rock>();

        rock.transform.position = transform.position;
        rock.transform.rotation = Quaternion.identity;
        rock.SetActive(true);

        //Pero que chanchada
        rock.GetComponent<Rock>().getRigidBody().AddForce(_velocity);
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