using UnityEngine;
using YG;

public class UpgradeCondition : MonoBehaviour
{
    private bool _isForestLevelUnlocked => YandexGame.savesData.HealthPowerUps >= 1;
    private bool _isCavesLevelUnlocked => YandexGame.savesData.HealthPowerUps >= 2 &&
        YandexGame.savesData.DamagePowerUps >= 1;
    private bool _isUnderseaLevelUnlocked => YandexGame.savesData.HealthPowerUps >= 3 &&
        YandexGame.savesData.DamagePowerUps >= 2;
    private bool _isDesertLevelUnlocked => YandexGame.savesData.HealthPowerUps >= 3 &&
        YandexGame.savesData.DamagePowerUps >= 3 &&
        YandexGame.savesData.GridPowerUps >= 1;
    private bool _isIceLevelUnlocked => YandexGame.savesData.HealthPowerUps >= 4 &&
        YandexGame.savesData.DamagePowerUps >= 4 &&
        YandexGame.savesData.GridPowerUps >= 2;
    private bool _isInfiniteLevelUnlocked => YandexGame.savesData.HealthPowerUps == 5 &&
        YandexGame.savesData.DamagePowerUps == 5 &&
        YandexGame.savesData.GridPowerUps == 3;
    private bool _isPirateLevelUnlocked => YandexGame.savesData.HealthPowerUps >= 3 &&
        YandexGame.savesData.DamagePowerUps >= 2 &&
        YandexGame.savesData.CoinsCount >= 200;
    private bool _isCursedLevelUnlocked => YandexGame.savesData.HealthPowerUps >= 3 &&
        YandexGame.savesData.DamagePowerUps >= 3 &&
        YandexGame.savesData.GridPowerUps >= 1 &&
        YandexGame.savesData.CoinsCount >= 500;


    public bool CheckAccess(int level)
    {
        return level switch
        {
            0 => true,
            1 => (_isForestLevelUnlocked),
            2 => (_isCavesLevelUnlocked),
            3 => (_isUnderseaLevelUnlocked),
            4 => (_isPirateLevelUnlocked),
            5 => (_isDesertLevelUnlocked),
            6 => (_isCursedLevelUnlocked),
            7 => (_isIceLevelUnlocked),
            8 => (_isInfiniteLevelUnlocked),
            _ => false,
        };
    }
}
