using UnityEngine;

public class PanelChanger : MonoBehaviour
{
    [SerializeField] private Transform _currentPanel;
    [SerializeField] private TimeManager _timeManager;

    public void Open(Transform panel)
    {
        if (Time.timeScale < 1)
            _timeManager.Unpause();

        _currentPanel.gameObject.SetActive(false);
        panel.gameObject.SetActive(true);
    }
}
