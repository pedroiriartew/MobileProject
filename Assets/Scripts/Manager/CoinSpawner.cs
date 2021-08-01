using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private UnityEngine.GameObject _coin;

    private float _posMinValue = -4f;
    private float _posMaxValue = 16f;

    private Vector3 _spawnPosition = new Vector3(0f, 0f, 0f);

    public void SpawnCoin(Vector3 playerPosition)
    {
        do
        {
            _spawnPosition = new Vector3(Random.Range(_posMinValue, _posMaxValue), playerPosition.y, playerPosition.z);
        } while (_spawnPosition == playerPosition);

        Instantiate(_coin,_spawnPosition, Quaternion.identity);
    }
}
