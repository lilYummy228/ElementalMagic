using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _playButton;

    private void OnEnable() => 
        _playButton.onClick.AddListener(Play);

    private void OnDisable() => 
        _playButton.onClick.RemoveListener(Play);

    private void Play() => 
        SceneManager.LoadScene("Game");
}
