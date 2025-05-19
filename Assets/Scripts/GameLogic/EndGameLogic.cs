using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameLogic
{
    public class EndGameLogic : MonoBehaviour
    {
        [SerializeField] private GameLogic _game;
        [SerializeField] private GameContinuation _gameContinuation;
        [SerializeField] private Transform _endGamePanel;
        [SerializeField] private Image _victoryImage;
        [SerializeField] private Image _defeatImage;
        [SerializeField] private TextMeshProUGUI _victoryText;
        [SerializeField] private TextMeshProUGUI _defeatText;
        [SerializeField] private Transform _adButton;
        [SerializeField] private TimeManager _timeManager;

        private bool _gameContinued;

        public event Action GameEnded;

        private void OnEnable()
        {
            _game.IsGameWinned += EndGame;
            _gameContinuation.GameContinued += CloseEndGamePanel;
        }

        private void OnDisable()
        {
            _game.IsGameWinned -= EndGame;
            _gameContinuation.GameContinued -= CloseEndGamePanel;
        }

        private void EndGame(bool isWinned)
        {
            GameEnded?.Invoke();

            _endGamePanel.gameObject.SetActive(true);

            ShowEndGamePanel(isWinned);

            _timeManager.Pause();
        }

        private void ShowEndGamePanel(bool isWinned)
        {
            _victoryImage.gameObject.SetActive(isWinned);
            _victoryText.gameObject.SetActive(isWinned);
            _defeatImage.gameObject.SetActive(!isWinned);
            _defeatText.gameObject.SetActive(!isWinned);

            if (_gameContinued == false)
                _adButton.gameObject.SetActive(!isWinned);
            else
                _adButton.gameObject.SetActive(false);
        }

        private void CloseEndGamePanel()
        {
            _endGamePanel.gameObject.SetActive(false);

            _game.GameContinued();

            _gameContinued = true;

            _timeManager.Unpause();
        }
    }
}