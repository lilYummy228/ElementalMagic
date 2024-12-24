using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour, IMenu
{
    [SerializeField] private Transform _levelsMenuPanel;

    public Transform MenuPanel => _levelsMenuPanel;

    public void LaunchLevel(int level) => 
        SceneManager.LoadScene(level);

    public void Open(Transform menuPanel)
    {
        _levelsMenuPanel.gameObject.SetActive(false);
        menuPanel.gameObject.SetActive(true);
    }
}
