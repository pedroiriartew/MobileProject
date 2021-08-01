using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Text _timer;
    [SerializeField] private Text _rockCount;
    [SerializeField] private Text _coinCount;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        _gameManager.UpdateTime += GameManager_UpdateTime;
        _gameManager.UpdateRocks += GameManager_UpdateRocks;
        _gameManager.UpdateCoins += Gamemanager_UpdateCoins;
        _gameManager.EndGameEvent += GameManager_EndGame;
    }

    private void GameManager_EndGame()
    {
        //Well Done Lad, the beatles are all dead
        UnsuscribeToGameManagerEvents();
    }

    private void Gamemanager_UpdateCoins(int coins)
    {
        _coinCount.text = coins.ToString();
    }

    private void GameManager_UpdateRocks(int rocks)
    {
        _rockCount.text = rocks.ToString();
    }

    private void GameManager_UpdateTime(float time)
    {
        _timer.text = ((int)time).ToString();
    }

    private void UnsuscribeToGameManagerEvents()
    {
        _gameManager.UpdateTime -= GameManager_UpdateTime;
        _gameManager.UpdateRocks -= GameManager_UpdateRocks;
        _gameManager.UpdateCoins -= Gamemanager_UpdateCoins;
        _gameManager.EndGameEvent -= GameManager_EndGame;
    }
}
