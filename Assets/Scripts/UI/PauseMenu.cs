using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private ElementConnector _elementConnector;
    [SerializeField] private VolumeSettings _volumeSettings;
    [SerializeField] private Transform _pauseMenu;
    [Header("Buttons")]
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _replayButton;

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(Pause);
        _resumeButton.onClick.AddListener(Unpause);
        _mainMenuButton.onClick.AddListener(GoToMainMenu);
        _replayButton.onClick.AddListener(Replay);        
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(Pause);
        _resumeButton.onClick.RemoveListener(Unpause);
        _mainMenuButton.onClick.RemoveListener(GoToMainMenu);
        _replayButton.onClick.RemoveListener(Replay);
    }

    private void Pause()
    {
        Time.timeScale = 0f;

        _pauseButton.gameObject.SetActive(false);
        _elementConnector.gameObject.SetActive(false);
        _pauseMenu.gameObject.SetActive(true);
    }

    private void Unpause()
    {
        Time.timeScale = 1f;

        _pauseButton.gameObject.SetActive(true);
        _elementConnector.gameObject.SetActive(true);
        _pauseMenu.gameObject.SetActive(false);
    }

    private void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    private void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
