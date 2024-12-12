using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private ElementConnector _elementConnector;
    [SerializeField] private VolumeSettings _volumeSettings;
    [SerializeField] private Transform _pauseMenuPanel;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private TimeManager _timeManager;

    private void Start() =>
        _volumeSettings.Setup();

    public void Pause()
    {
        _timeManager.Stop();

        foreach (Button button in _buttons)
            button.gameObject.SetActive(false);

        _elementConnector.gameObject.SetActive(false);
        _pauseMenuPanel.gameObject.SetActive(true);
    }

    public void Unpause()
    {
        _timeManager.Start();

        foreach (Button button in _buttons)
            button.gameObject.SetActive(true);

        _elementConnector.gameObject.SetActive(true);
        _pauseMenuPanel.gameObject.SetActive(false);
    }

    public void LoadScene(int levelId)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelId);
    }
}