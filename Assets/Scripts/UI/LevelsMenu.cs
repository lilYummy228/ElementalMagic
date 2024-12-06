using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour, IMenu
{
    [SerializeField] private Transform _levelsMenuPanel;
    [SerializeField] private Transform[] _levels;

    public Transform MenuPanel => _levelsMenuPanel;

    public void LaunchLevel(int level) => 
        SceneManager.LoadScene(level);

    public void Open(Transform menuPanel)
    {
        _levelsMenuPanel.gameObject.SetActive(false);
        menuPanel.gameObject.SetActive(true);
    }

    public void ShowLevel(int levelIndex)
    {
        foreach (Transform level in _levels)
            level.gameObject.SetActive(false);

        _levels[levelIndex].gameObject.SetActive(true);
    }
}
