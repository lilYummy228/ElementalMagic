using System;
using TMPro;
using UnityEngine;

public class StatisticsView : MonoBehaviour
{
    [SerializeField] private StatisticsCollector _stats;
    [SerializeField] private TextMeshProUGUI _timer;
    [SerializeField] private TextMeshProUGUI _connectedElements;
    [SerializeField] private TextMeshProUGUI _collectedCoins;

    private void OnEnable()
    {
        _stats.TimerStopped += ShowTimer;
        _stats.ConnectedElementsCountStopped += ShowConnectedElementsCount;
        _stats.CollectedCoinsStopped += ShowCollectedCoins;
    }    

    private void OnDisable()
    {
        _stats.TimerStopped -= ShowTimer;
        _stats.ConnectedElementsCountStopped -= ShowConnectedElementsCount;
        _stats.CollectedCoinsStopped -= ShowCollectedCoins;
    }

    private void ShowTimer(int minutes, int seconds) => 
        _timer.text = $"{minutes}:{seconds}";

    private void ShowConnectedElementsCount(int count) => 
        _connectedElements.text = $"{count}";

    private void ShowCollectedCoins(int count) => 
        _collectedCoins.text = $"{count}";
}
