using UnityEngine;
using YG;

public class PowerUpSaveSystem : MonoBehaviour, ISaveSystem
{
    [SerializeField] private PowerUp _healthPowerUp;
    [SerializeField] private PowerUp _damagePowerUp;
    [SerializeField] private PowerUp _gridPowerUp;
    [SerializeField] private Wallet _wallet;

    private void OnEnable() => 
        Load();

    private void OnDisable() => 
        Save();

    public void Load()
    {
        _healthPowerUp.SetPowerUpsCount(YandexGame.savesData.HealthPowerUps);
        _damagePowerUp.SetPowerUpsCount(YandexGame.savesData.DamagePowerUps);
        _gridPowerUp.SetPowerUpsCount(YandexGame.savesData.GridPowerUps);
        _wallet.SetCount(YandexGame.savesData.CoinsCount);
    }

    public void Save()
    {
        YandexGame.savesData.HealthPowerUps = _healthPowerUp.PowerUpsCount;
        YandexGame.savesData.DamagePowerUps = _damagePowerUp.PowerUpsCount;
        YandexGame.savesData.GridPowerUps = _gridPowerUp.PowerUpsCount;
        YandexGame.savesData.CoinsCount = _wallet.Count;

        YandexGame.SaveProgress();
    }

    [ContextMenu("Refresh")]
    public void Refresh()
    {
        _healthPowerUp.SetPowerUpsCount(default);
        _damagePowerUp.SetPowerUpsCount(default);
        _gridPowerUp.SetPowerUpsCount(default);
    }
}
