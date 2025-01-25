using System;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private GameBoard _gameBoard;
    [SerializeField] private ElementConnector _elementConnector;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Player _player;
    [SerializeField] private Button _refreshButton;
    [SerializeField] private Counter _counter;

    public event Action<bool> IsGameWinned;
    public event Action GameStarted;

    private void Start()
    {
        _player.Health.Dead += LoseGame;
        _enemySpawner.AllEnemiesDied += WinGame;

        _counter.StartCountDown();
    }

    private void OnEnable()
    {
        _elementConnector.gameObject.SetActive(false);
        _counter.Counted += StartGame;
    }

    private void OnDisable()
    {
        _counter.Counted -= StartGame;
        _enemySpawner.AllEnemiesDied -= WinGame;
        _player.Health.Dead -= LoseGame;
    }

    public void GameContinued()
    {
        _counter.StartCountDown();

        _player.Health.SetHealth(_player.HealthContinueValue);
        _player.Health.StartDeathControl();
    }

    private void StartGame()
    {
        GameStarted?.Invoke();

        _refreshButton.gameObject.SetActive(true);

        _elementConnector.gameObject.SetActive(true);

        _gameBoard.FillBoard();

        _enemySpawner.Spawn();
        _enemySpawner.RefreshAttack();
    }

    private void LoseGame()
    {
        EndGame();
        IsGameWinned?.Invoke(false);
    }

    private void WinGame()
    {
        EndGame();
        IsGameWinned?.Invoke(true);
    }

    private void EndGame() => 
        _elementConnector.gameObject.SetActive(false);    
}
