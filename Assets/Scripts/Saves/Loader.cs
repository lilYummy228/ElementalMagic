using Lean.Localization;
using UnityEngine;
using YG;

public class Loader : MonoBehaviour
{
    [SerializeField] private AudioSaveSystem _audioSaveSystem;
    [SerializeField] private PowerUpSaveSystem _powerUpSaveSystem;
    [SerializeField] private WalletSaveSystem _walletSaveSystem;
    [SerializeField] private LeanLocalization _leanLocalization;  

    private void Start()
    {
        SwitchLanguage();

        Load();
    }

    private void SwitchLanguage()
    {
        switch (YandexGame.EnvironmentData.language)
        {
            case "ru":
                _leanLocalization.SetCurrentLanguage("Russian");
                break;

            case "en":
                _leanLocalization.SetCurrentLanguage("English");
                break;

            case "tr":
                _leanLocalization.SetCurrentLanguage("Turkey");
                break;
        }
    }

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
    }
}
