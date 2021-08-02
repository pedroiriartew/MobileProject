using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{

    private float _posMinValue = -4f;
    private float _posMaxValue = 16f;

    private Vector3 _spawnPosition = new Vector3(0f, 0f, 0f);

    public void SpawnCoin(Vector3 playerPosition)
    {
        do
        {
            _spawnPosition = new Vector3(Random.Range(_posMinValue, _posMaxValue), playerPosition.y, playerPosition.z);
        } while (_spawnPosition == playerPosition);

        GameObject coin = PoolManager.Instance.GetPoolObject("Coin");
        coin.AddComponent<Coin>();

        coin.transform.position = transform.position;
        coin.transform.rotation = Quaternion.identity;
        coin.SetActive(true);

        Instantiate(coin,_spawnPosition, Quaternion.identity);
    }
}
