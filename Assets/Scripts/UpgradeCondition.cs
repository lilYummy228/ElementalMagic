using UnityEngine;
using YG;

public class UpgradeCondition : MonoBehaviour
{
    private bool _isFirstLevelUnlocked => YandexGame.savesData.HealthPowerUps >= 1;
    private bool _isSecondLevelUnlocked => YandexGame.savesData.HealthPowerUps >= 2 &&
        YandexGame.savesData.DamagePowerUps >= 1;
    private bool _isThirdLevelUnlocked => YandexGame.savesData.HealthPowerUps >= 3 &&
        YandexGame.savesData.DamagePowerUps >= 2;
    private bool _isFouthLevelUnlocked => YandexGame.savesData.HealthPowerUps >= 3 &&
        YandexGame.savesData.DamagePowerUps >= 3 &&
        YandexGame.savesData.GridPowerUps >= 1;
    private bool _isFifthLevelUnlocked => YandexGame.savesData.HealthPowerUps >= 4 &&
        YandexGame.savesData.DamagePowerUps >= 4 &&
        YandexGame.savesData.GridPowerUps >= 2;
    private bool _isInfiniteLevelUnlocked => YandexGame.savesData.HealthPowerUps == 5 &&
        YandexGame.savesData.DamagePowerUps == 5 &&
        YandexGame.savesData.GridPowerUps == 3;


    public bool Check(int level)
    {
        return level switch
        {
            0 => true,
            1 => (_isFirstLevelUnlocked),
            2 => (_isSecondLevelUnlocked),
            3 => (_isThirdLevelUnlocked),
            4 => (_isFouthLevelUnlocked),
            5 => (_isFifthLevelUnlocked),
            6 => (_isInfiniteLevelUnlocked),
            _ => false,
        };
    }
}
