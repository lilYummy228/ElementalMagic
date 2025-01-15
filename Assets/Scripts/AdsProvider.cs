using UnityEngine;
using YG;

public class AdsProvider : MonoBehaviour
{
    public void ShowInterstitialAd() =>
        YandexGame.FullscreenShow();

    public void ShowRewardedAd(int id)
    {
        if (YandexGame.savesData.HealthPowerUps > 0)
            YandexGame.RewVideoShow(id);
    }
}
