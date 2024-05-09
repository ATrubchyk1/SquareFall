using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _gameStartScreen;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private SquareSpawner _squareSpawner;
    
    [SerializeField] private float _gameOverScreenShowDelay;

    private bool _wasGameOver;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        
        _gameScreen.SetActive(false);
        _gameOverScreen.SetActive(false);
        _gameStartScreen.SetActive(true);
    }

    private void Update()
    {
        if (!_wasGameOver) return;
        _gameOverScreenShowDelay -= Time.deltaTime;
        if (_gameOverScreenShowDelay <= 0)
        {
            ShowGameOverScreen();
        }
    }

    public void StartGame()
    {
        _gameStartScreen.SetActive(false);
        _gameScreen.SetActive(true);
    }

    public void RestartGame()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void OnPlayerDied()
    {
        _wasGameOver = true;
        _squareSpawner.enabled = false;
    }

    private void ShowGameOverScreen()
    {
        _gameScreen.SetActive(false);
        _gameOverScreen.SetActive(true);
    }
}
