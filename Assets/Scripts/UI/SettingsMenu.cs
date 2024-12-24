using UnityEngine;

public class SettingsMenu : MonoBehaviour, IMenu
{
    [SerializeField] private Transform _settingsMenuPanel;
    [SerializeField] private VolumeSettings _volumeSettings;

    public Transform MenuPanel => _settingsMenuPanel;

    private void Start() =>
        _volumeSettings.Setup();

    public void Open(Transform menuPanel)
    {
        _settingsMenuPanel.gameObject.SetActive(false);
        menuPanel.gameObject.SetActive(true);
    }
}