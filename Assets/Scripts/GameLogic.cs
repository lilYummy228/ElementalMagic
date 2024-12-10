using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _startGameCounter;
    [SerializeField] private GameBoard _gameBoard;
    [SerializeField] private ElementConnector _elementConnector;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Player _player;
    [SerializeField] private Button _refreshButton;
    [SerializeField] private int _startGameCount = 3;
    [SerializeField] private string _startGameText = "GO!";

    private float _waitTime = 0.75f;

    public event Action<bool> HasGameWinned;
    public WaitForSeconds Wait => new(_waitTime);

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
        _elementConnector.gameObject.SetActive(false);

        for (int i = _startGameCount; i > 0; i--)
        {
            _startGameCounter.text = i.ToString();

            yield return Wait;
        }

        _startGameCounter.text = _startGameText;

        yield return Wait;

        _startGameCounter.text = null;

        StartGame();
    }

    private void StartGame()
    {
        _refreshButton.gameObject.SetActive(true);
        _elementConnector.gameObject.SetActive(true);
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
