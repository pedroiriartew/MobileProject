using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private string _name;
    private GameObject _poolObject;
    private int _poolCount;
    private Vector3 _cemetery;

    //variables de uso
    private GameObject[] _poolObjects;

    public void Initialize(string name, GameObject poolObject, int poolCount, Vector3 cemetery, Transform parent)
    {
        _name = name;
        _poolObject = poolObject;
        _poolCount = poolCount;
        _cemetery = cemetery;

        InstantiatePool(parent);
    }

    private void InstantiatePool(Transform parent)
    {
        _poolObjects = new GameObject[_poolCount];

        for (int i = 0; i < _poolObjects.Length; i++)
        {
            _poolObjects[i] = Instantiate(_poolObject, parent);
            MoveToCemetery(_poolObjects[i]);
        }
    }

    public GameObject GetPoolObject()
    {
        foreach (GameObject go in _poolObjects)
        {
            if (!go.activeSelf)
            {
                return go;
            }
        }

        return null; //Mala práctica
    }


    private void MoveToCemetery(GameObject _objectPool)
    {
        _objectPool.SetActive(false);
        _objectPool.transform.position = _cemetery;
    }
}
