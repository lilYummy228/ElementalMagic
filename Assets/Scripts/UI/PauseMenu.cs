using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private ElementConnector _elementConnector;
    [SerializeField] private VolumeSettings _volumeSettings;
    [SerializeField] private Transform _pauseMenuPanel;

    public Transform MenuPanel => _pauseMenuPanel;

    private void Start() => 
        _volumeSettings.Setup();

    public void Pause()
    {
        Time.timeScale = 0f;

        _elementConnector.gameObject.SetActive(false);
        _pauseMenuPanel.gameObject.SetActive(true);
    }

    public void Unpause()
    {
        Time.timeScale = 1f;

        _elementConnector.gameObject.SetActive(true);
        _pauseMenuPanel.gameObject.SetActive(false);
    }

    public void LoadScene(int id)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(id);
    }
}
