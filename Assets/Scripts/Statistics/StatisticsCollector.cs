using UI;
using Elements;
using GameLogic;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Statistics
{
    public class StatisticsCollector : MonoBehaviour
    {
        [SerializeField] private ElementConnector _elementConnector;
        [SerializeField] private GameLogic.GameLogic _game;
        [SerializeField] private EndGameLogic _endGameLogic;
        [SerializeField] private Enemy.Enemy _enemy;
        [SerializeField] private Counter _counter;

        private int _elementsPopped;
        private int _coinsCollected;

        public event Action<int> ConnectedElementsCountStopped;
        public event Action<int> CollectedCoinsStopped;

        public Counter Counter => _counter;

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

        private void StartCountingTime() =>
            _counter.StartCountTime();

        private void AddElementCount(IReadOnlyList<Element> elements) =>
            _elementsPopped += elements.Count;

        private void StopCountingTime()
        {
            _counter.StopCountTime();

            ConnectedElementsCountStopped?.Invoke(_elementsPopped);
            CollectedCoinsStopped?.Invoke(_coinsCollected);
        }

        private void AddCoinCount(int count) =>
            _coinsCollected += count;
    }
}