using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private AdsProvider _adsProvider;

    public void LaunchLevel(int level)
    {
        _adsProvider.ShowInterstitialAd();

        SceneManager.LoadScene(level);
    }
}
