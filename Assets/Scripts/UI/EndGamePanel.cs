using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(TextMeshProUGUI))]
public class EndGamePanel : MonoBehaviour
{
    private const string WinText = "You win!";
    private const string LoseText = "You lose!";
    private const float MaxTextSize = 150f;
    private const float MinTextSize = 110f;

    [SerializeField] private GameLogic _game;
    [SerializeField] private int _endGameDelay = 6;

    private TextMeshProUGUI _text;
    private WaitUntil _waitIncrease;
    private WaitUntil _waitDecrease;
    private float _animationStep = 0.5f;
    private bool _isWinned;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _waitIncrease = new WaitUntil(() => (_text.fontSize += _animationStep) == MaxTextSize);
        _waitDecrease = new WaitUntil(() => (_text.fontSize -= _animationStep) == MinTextSize);
    }

    private void OnEnable() =>
        _game.HasGameWinned += EndGame;

    private void OnDisable() =>
        _game.HasGameWinned -= EndGame;

    private void EndGame(bool isWinned)
    {
        _isWinned = isWinned;

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
            yield return _waitIncrease;

            yield return _waitDecrease;
        }

        SceneManager.LoadScene("MainMenu");
    }
}
