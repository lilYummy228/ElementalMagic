using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Transform _pausePanel;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private ElementConnector _elementConnector;
    [Header("Buttons")]
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _replayButton;
    [Header("Sliders")] 
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundsSlider;

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

        _elementConnector.gameObject.SetActive(false);
        _pausePanel.gameObject.SetActive(true);
    }

    private void Unpause()
    {
        Time.timeScale = 1f;
        _elementConnector.gameObject.SetActive(true);
        _pausePanel.gameObject.SetActive(false);
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
