using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _startGameCounter;
    [SerializeField] private GameBoard _gameBoard;
    [SerializeField] private ElementConnector _elementConnector;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Player _player;
    [SerializeField] private int _startGameCount = 3;
    [SerializeField] private string _startGameText = "GO!";

    public event Action<bool> HasGameWinned;

    private WaitForSeconds _wait;
    private float _waitTime = 1f;

    private void Awake() =>
        _wait = new WaitForSeconds(_waitTime);

    private void OnDisable()
    {
        _enemySpawner.AllEnemiesDied -= WinGame;
        _player.Health.Dead -= LoseGame;
    }

    private void Start()
    {
        _player.Health.Dead += LoseGame;
        _enemySpawner.AllEnemiesDied += WinGame;

        StartCoroutine(nameof(CountDown));
    }

    private IEnumerator CountDown()
    {
        for (int i = _startGameCount; i > 0; i--)
        {
            _startGameCounter.text = i.ToString();

            yield return _wait;
        }

        _startGameCounter.text = _startGameText;

        yield return _wait;

        _startGameCounter.text = null;

        StartGame();
    }

    private void StartGame()
    {
        _gameBoard.FillBoard();
        _enemySpawner.Spawn();
    }

    private void LoseGame()
    {
        EndGame();
        HasGameWinned?.Invoke(false);
    }

    private void WinGame()
    {
        EndGame();
        HasGameWinned?.Invoke(true);
    }

    private void EndGame() => 
        _elementConnector.gameObject.SetActive(false);
}