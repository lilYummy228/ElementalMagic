using UnityEngine;
using YG;

namespace Upgrades
{
    public class UpgradeCondition : MonoBehaviour
    {
        private bool IsForestLevelUnlocked => YandexGame.savesData.healthPowerUps >= 1;
        private bool IsCavesLevelUnlocked => YandexGame.savesData.healthPowerUps >= 2 &&
            YandexGame.savesData.damagePowerUps >= 1;
        private bool IsUnderseaLevelUnlocked => YandexGame.savesData.healthPowerUps >= 3 &&
            YandexGame.savesData.damagePowerUps >= 2;
        private bool IsDesertLevelUnlocked => YandexGame.savesData.healthPowerUps >= 3 &&
            YandexGame.savesData.damagePowerUps >= 3 &&
            YandexGame.savesData.gridPowerUps >= 1;
        private bool IsIceLevelUnlocked => YandexGame.savesData.healthPowerUps >= 4 &&
            YandexGame.savesData.damagePowerUps >= 4 &&
            YandexGame.savesData.gridPowerUps >= 2;
        private bool IsInfiniteLevelUnlocked => YandexGame.savesData.healthPowerUps == 5 &&
            YandexGame.savesData.damagePowerUps == 5 &&
            YandexGame.savesData.gridPowerUps == 3;
        private bool IsPirateLevelUnlocked => YandexGame.savesData.healthPowerUps >= 3 &&
            YandexGame.savesData.damagePowerUps >= 2 &&
            YandexGame.savesData.coinsCount >= 200;
        private bool IsCursedLevelUnlocked => YandexGame.savesData.healthPowerUps >= 3 &&
            YandexGame.savesData.damagePowerUps >= 3 &&
            YandexGame.savesData.gridPowerUps >= 1 &&
            YandexGame.savesData.coinsCount >= 500;

        public bool CheckAccess(int level)
        {
            return level switch
            {
                0 => true,
                1 => IsForestLevelUnlocked,
                2 => IsCavesLevelUnlocked,
                3 => IsUnderseaLevelUnlocked,
                4 => IsPirateLevelUnlocked,
                5 => IsDesertLevelUnlocked,
                6 => IsCursedLevelUnlocked,
                7 => IsIceLevelUnlocked,
                8 => IsInfiniteLevelUnlocked,
                _ => false,
            };
        }
    }
}