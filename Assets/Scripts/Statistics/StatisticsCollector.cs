using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsCollector : MonoBehaviour
{
    private const int SecondsPerMinute = 60;
    private const int Second = 1;

    [SerializeField] private ElementConnector _elementConnector;
    [SerializeField] private GameLogic _game;
    [SerializeField] private EndGameLogic _endGameLogic;
    [SerializeField] private Enemy _enemy;

    private int _elementsPopped;
    private int _coinsCollected;
    private int _minutes;
    private int _seconds;
    private WaitForSeconds _wait;

    public event Action<int, int> TimerStopped;
    public event Action<int> ConnectedElementsCountStopped;
    public event Action<int> CollectedCoinsStopped;

    private void Awake() =>
        _wait = new WaitForSeconds(Second);

    private void OnEnable()
    {
        _elementConnector.ElementsFilled += AddElementCount;
        _game.GameStarted += StartCountingTime;
        _endGameLogic.GameEnded += StopCountingTime;
        _enemy.EnemyCoinsCollected += AddCoinCount;
    }    

    private void OnDisable()
    {
        _elementConnector.ElementsFilled -= AddElementCount;
        _game.GameStarted -= StartCountingTime;
        _endGameLogic.GameEnded -= StopCountingTime;
        _enemy.EnemyCoinsCollected -= AddCoinCount;
    }

    private void AddElementCount(IReadOnlyList<Element> elements) =>
        _elementsPopped += elements.Count;

    private void StartCountingTime() =>
        StartCoroutine(nameof(CountTime));

    private void StopCountingTime()
    {
        StopCoroutine(nameof(CountTime));

        TimerStopped?.Invoke(_minutes, _seconds);
        ConnectedElementsCountStopped?.Invoke(_elementsPopped);
        CollectedCoinsStopped?.Invoke(_coinsCollected);
    }

    private void AddCoinCount(int count) => 
        _coinsCollected += count;

    private IEnumerator CountTime()
    {
        while (enabled)
        {
            if (_seconds == SecondsPerMinute)
            {
                _minutes++;
                _seconds = default;
            }
            else
            {
                _seconds++;
            }

            yield return _wait;
        }
    }
}
