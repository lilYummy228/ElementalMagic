using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGamePanel : MonoBehaviour
{
    private const string WinText = "You win!";
    private const string LoseText = "You lose!";
    private const float MaxTextSize = 150f;
    private const float MinTextSize = 110f;

    [SerializeField] private GameLogic _game;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private int _endGameDelay = 3;
    [SerializeField] private TextMeshProUGUI _text;

    private float _waitTime = 0.2f;
    private float _animationStep = 50f;
    private bool _isWinned;

    public WaitUntil WaitIncrease => new(() => Mathf.Round(_text.fontSize += _animationStep * Time.deltaTime) >= Mathf.Round(MaxTextSize));
    public WaitUntil WaitDecrease => new(() => Mathf.Round(_text.fontSize -= _animationStep * Time.deltaTime) <= Mathf.Round(MinTextSize));
    public WaitForSeconds WaitForSeconds => new(_waitTime);

    private void OnEnable() =>
        _game.HasGameWinned += EndGame;

    private void OnDisable() =>
        _game.HasGameWinned -= EndGame;

    private void EndGame(bool isWinned)
    {
        _isWinned = isWinned;

        _pauseButton.gameObject.SetActive(false);

        StartCoroutine(nameof(ShowEndGamePanel));
    }

    private IEnumerator ShowEndGamePanel()
    {
        if (_isWinned)
            _text.text = WinText;
        else
            _text.text = LoseText;

        for (int i = 0; i < _endGameDelay; i++)
        {
            yield return WaitForSeconds;

            yield return WaitIncrease;

            yield return WaitForSeconds;

            yield return WaitDecrease;
        }

        SceneManager.LoadScene(0);
    }
}
