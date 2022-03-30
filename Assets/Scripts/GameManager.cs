using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState gameState;
    public static event Action<GameState> OnGameStateChanged;

    public GameObject StartTxt;
    public GameObject PinBall;

    void Awake()
    {
        Instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateGameState(GameState.Idle);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGameState(GameState newState)
    {
        switch (newState)
        {
            case GameState.Idle:
                gameState = GameState.Idle;
                break;
            case GameState.Playing:
                GamePlaying();
                break;
            case GameState.WinGame:
                break;
            case GameState.EndLevel:
                break;
            case GameState.GameOver:
                break;
        }
        OnGameStateChanged?.Invoke(newState);
    }

    public void GamePlaying()
    {
        StartTxt.SetActive(false);
    }
    
}

public enum GameState
{
    Idle, 
    Playing, 
    WinGame, 
    EndLevel, 
    GameOver
}
