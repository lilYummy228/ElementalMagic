using Shop;
using UnityEngine;
using YG;

namespace Saves
{
    public class PowerUpSaveSystem : MonoBehaviour, ISaveSystem
    {
        [SerializeField] private PowerUp _healthPowerUp;
        [SerializeField] private PowerUp _damagePowerUp;
        [SerializeField] private PowerUp _gridPowerUp;

        public void Load()
        {
            _healthPowerUp.SetPowerUpsCount(YandexGame.savesData.healthPowerUps);
            _damagePowerUp.SetPowerUpsCount(YandexGame.savesData.damagePowerUps);
            _gridPowerUp.SetPowerUpsCount(YandexGame.savesData.gridPowerUps);
        }

        public void Save()
        {
            YandexGame.savesData.healthPowerUps = _healthPowerUp.PowerUpsCount;
            YandexGame.savesData.damagePowerUps = _damagePowerUp.PowerUpsCount;
            YandexGame.savesData.gridPowerUps = _gridPowerUp.PowerUpsCount;

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
}