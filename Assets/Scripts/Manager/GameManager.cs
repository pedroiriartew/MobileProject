using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Delegates and Events
    public delegate void UpdateTimeHUD(float time);
    public delegate void UpdateValuesHUD(int values);
    public delegate void UpdateEndGame();

    public event UpdateTimeHUD UpdateTime;
    public event UpdateValuesHUD UpdateCoins;
    public event UpdateValuesHUD UpdateRocks;
    public event UpdateEndGame EndGameEvent;
    #endregion

    [SerializeField] private int _rocksToNextCoin = 2;//How many rocks I needed for a coin to spawn.
    [SerializeField] private float _levelDuration = 120f;

    private PlayerMovement _playerMovementReference;
    private PlayerCollisionHandler _playerCollisionsReference;
    [SerializeField] private Objective _objectiveReference;
    [SerializeField] private CoinSpawner _coinSpawner;
    private int _rocksAmount = 0;
    private int _coinsAmount = 0;

    private void Awake()
    {
        _playerMovementReference = FindObjectOfType<PlayerMovement>();
        _playerCollisionsReference = FindObjectOfType<PlayerCollisionHandler>();
    }

    private void Start()
    {
        _playerCollisionsReference.Coin += UpdateCoinCount;
        _objectiveReference.IsRockColliding += UpdateRockCount;
    }

    private void Update()
    {
        AdvanceLevelTime();
    }

    private void AdvanceLevelTime()
    {
        _levelDuration -= Time.deltaTime;

        UpdateTime?.Invoke(_levelDuration);

        if (_levelDuration <= 0.0f)
        {
            StopAllCoroutines();
            EndGameEvent?.Invoke();
            UnsuscribeToEvents();
        }
    }

    private void UnsuscribeToEvents()
    {
        _playerCollisionsReference.Coin -= UpdateCoinCount;
        _objectiveReference.IsRockColliding -= UpdateRockCount;
    }

    public void UpdateCoinCount()
    {
        _coinsAmount++;

        UpdateCoins?.Invoke(_coinsAmount);
    }

    public void UpdateRockCount()
    {
        _rocksAmount++;

        UpdateRocks?.Invoke(_rocksAmount);
        CheckToSpawnCoin();
    }

    private void CheckToSpawnCoin()
    {
        if (_rocksAmount == _rocksToNextCoin)
        {
            _coinSpawner.SpawnCoin(_playerMovementReference.transform.position);
            _rocksToNextCoin += _rocksToNextCoin;
        }
    }
}
