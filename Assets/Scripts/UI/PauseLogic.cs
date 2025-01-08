using UnityEngine;
using UnityEngine.UI;

public class PauseLogic : MonoBehaviour
{
    [SerializeField] private ElementConnector _elementConnector;
    [SerializeField] private VolumeSettings _volumeSettings;
    [SerializeField] private Transform _pauseMenuPanel;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private TimeManager _timeManager;

    public void Pause()
    {
        _timeManager.Pause();

        foreach (Button button in _buttons)
            button.gameObject.SetActive(false);

        _elementConnector.gameObject.SetActive(false);
        _pauseMenuPanel.gameObject.SetActive(true);
    }

    public void Unpause()
    {
        _timeManager.Unpause();

        foreach (Button button in _buttons)
            button.gameObject.SetActive(true);

        _elementConnector.gameObject.SetActive(true);
        _pauseMenuPanel.gameObject.SetActive(false);
    }
}