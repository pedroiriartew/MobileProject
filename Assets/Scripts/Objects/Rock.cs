using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private float _lifeSpan = 5;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void DestroyRock()
    {
        StartCoroutine(DestroyCoroutine());
    }

    public void DestroyOnObjective()
    {
        PoolManager.Instance.SendToCemetery("Rock", gameObject);
    }

    public IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(_lifeSpan);

        PoolManager.Instance.SendToCemetery("Rock", gameObject);
    }

    public Rigidbody2D getRigidBody()
    {
        return _rb;
    }
}
