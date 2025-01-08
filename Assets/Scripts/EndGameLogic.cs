using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameLogic : MonoBehaviour
{
    [SerializeField] private GameLogic _game;
    [SerializeField] private Transform _endGamePanel;
    [SerializeField] private Image _victoryImage;
    [SerializeField] private Image _defeatImage;
    [SerializeField] private TextMeshProUGUI _victoryText;
    [SerializeField] private TextMeshProUGUI _defeatText;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private TimeManager _timeManager;

    public event Action GameEnded;

    private void OnEnable() =>
        _game.IsGameWinned += ShowEndGamePanel;

    private void OnDisable() =>
        _game.IsGameWinned -= ShowEndGamePanel;

    private void ShowEndGamePanel(bool isWinned)
    {
        GameEnded?.Invoke();

        _endGamePanel.gameObject.SetActive(true);

        if (isWinned)
        {
            _nextLevelButton.gameObject.SetActive(true);
            _victoryImage.gameObject.SetActive(true);
            _victoryText.gameObject.SetActive(true);
        }
        else
        {
            _nextLevelButton.gameObject.SetActive(false);
            _defeatImage.gameObject.SetActive(true);
            _defeatText.gameObject.SetActive(true);
        }
        
        _timeManager.Pause();
    }
}
