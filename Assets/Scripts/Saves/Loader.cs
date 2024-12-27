using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField] private AudioSaveSystem _audioSaveSystem;
    [SerializeField] private PowerUpSaveSystem _powerUpSaveSystem;

    private void Start() =>
        Load();

    private void OnDisable()
    {
        _audioSaveSystem.Save();
        _powerUpSaveSystem.Save();
    }

    private void Load()
    {
        _audioSaveSystem.Load();
        _powerUpSaveSystem.Load();
    }
}
