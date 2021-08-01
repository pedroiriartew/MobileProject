﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //Todas las pools de la escena
    [SerializeField] private PoolData[] _poolsData;

    //Variables de Uso
    private Pool[] _pools;

    private void Awake()
    {
        _pools = new Pool[_poolsData.Length];

        for (int i = 0; i < _pools.Length; i++)
        {
            _pools[i] = new GameObject().AddComponent<Pool>();
            _pools[i].gameObject.name = _poolsData[i].Name;

            _pools[i].Initialize(_poolsData[i].Name, _poolsData[i].PoolObject, _poolsData[i].PoolCount, _poolsData[i].Cemetery, _pools[i].transform);
        }        
    }

    /// <summary>
    /// Devuelve el Objeto de la Pool y si no hay nada devuelve null. Hay que atajarse.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>

    public GameObject GetPoolObject(string name)
    {
        foreach (Pool pool in _pools)
        {
            if (pool.name == name)
            {
                return pool.GetPoolObject();
            }
        }

        return null;//Mala práctica y hay que cuidarse de esto.
    }

}


[System.Serializable]
public class PoolData
{
    [SerializeField] private string _name;
    public string Name { get { return _name; } }

    [SerializeField] private GameObject _poolObject;
    public GameObject PoolObject { get { return _poolObject; } }

    [SerializeField] private int _poolCount;
    public int PoolCount { get { return _poolCount; } }

    [SerializeField] private Vector3 _cemetery;
    public Vector3 Cemetery { get { return _cemetery; } }
}
