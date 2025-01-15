using UnityEngine;
using YG;

public class Loader : MonoBehaviour
{
    [SerializeField] private AudioSaveSystem _audioSaveSystem;
    [SerializeField] private PowerUpSaveSystem _powerUpSaveSystem;
    [SerializeField] private WalletSaveSystem _walletSaveSystem;

    private void Start() => 
        Load();

    private void OnDisable() =>
        Save(); 

    private void OnApplicationQuit() =>
        Save();

    private void Load()
    {
        _audioSaveSystem.Load();
        _powerUpSaveSystem.Load();
        _walletSaveSystem.Load();
    }

    private void Save()
    {
        _walletSaveSystem.Save();
        _audioSaveSystem.Save();
        _powerUpSaveSystem.Save();

        YandexGame.SaveProgress();
    }
}
