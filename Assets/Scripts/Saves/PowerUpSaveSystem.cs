using UnityEngine;
using YG;

public class PowerUpSaveSystem : MonoBehaviour, ISaveSystem
{
    [SerializeField] private PowerUp _healthPowerUp;
    [SerializeField] private PowerUp _damagePowerUp;
    [SerializeField] private PowerUp _gridPowerUp;    

    public void Load()
    {
        _healthPowerUp.SetPowerUpsCount(YandexGame.savesData.HealthPowerUps);
        _damagePowerUp.SetPowerUpsCount(YandexGame.savesData.DamagePowerUps);
        _gridPowerUp.SetPowerUpsCount(YandexGame.savesData.GridPowerUps);        
    }

    public void Save()
    {
        YandexGame.savesData.HealthPowerUps = _healthPowerUp.PowerUpsCount;
        YandexGame.savesData.DamagePowerUps = _damagePowerUp.PowerUpsCount;
        YandexGame.savesData.GridPowerUps = _gridPowerUp.PowerUpsCount;
        
        YandexGame.SaveProgress();
    }

    [ContextMenu("Refresh")]
    public void Refresh()
    {
        _healthPowerUp.SetPowerUpsCount(default);
        _damagePowerUp.SetPowerUpsCount(default);
        _gridPowerUp.SetPowerUpsCount(default);

        _healthPowerUp.Setup();
        _damagePowerUp.Setup();
        _gridPowerUp.Setup();

        Save();
    }
}
