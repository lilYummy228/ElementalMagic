using UnityEngine;
using YG;

public class AdsProvider : MonoBehaviour
{
    public void ShowInterstitialAd() =>
        YandexGame.FullscreenShow();

    public void ShowRewardedAd(int id) => 
        YandexGame.RewVideoShow(id);
}
