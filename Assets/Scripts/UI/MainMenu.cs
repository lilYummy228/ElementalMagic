using UnityEngine;

public class MainMenu : MonoBehaviour, IMenu
{
    [SerializeField] private Transform _mainMenuPanel;

    public Transform MenuPanel => _mainMenuPanel;

    public void Open(Transform menuPanel)
    {
        _mainMenuPanel.gameObject.SetActive(false);
        menuPanel.gameObject.SetActive(true);
    }
}
