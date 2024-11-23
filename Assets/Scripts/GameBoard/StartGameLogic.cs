using System.Collections;
using UnityEngine;

public class StartGameLogic : MonoBehaviour
{
    [SerializeField] private Sprite[] _startGameCounter;
    [SerializeField] private SpriteRenderer _counter;
    [SerializeField] private GameBoard _gameBoard;
    [SerializeField] private EnemySpawner _enemySpawner;

    private WaitForSeconds _wait;
    private float _waitTime = 1f;

    private void Awake() => 
        _wait = new WaitForSeconds(_waitTime);

    private void OnEnable() => 
        StartCoroutine(nameof(CountDown));

    private IEnumerator CountDown()
    {
        foreach (Sprite sprite in _startGameCounter)
        {
            _counter.sprite = sprite;

            yield return _wait;
        }

        _counter.sprite = null;

        StartGame();
    }

    private void StartGame()
    {
        _gameBoard.FillBoard();
        _enemySpawner.Spawn();
    }
}
