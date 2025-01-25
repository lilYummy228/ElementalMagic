using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private AdsProvider _adsProvider;
    [SerializeField] private UpgradeCondition _upgradeChecker;

    public void LaunchLevel(int level)
    {
        if (_upgradeChecker.CheckAccess(level))
        {
            _adsProvider.ShowInterstitialAd();

            SceneManager.LoadScene(level);
        }
    }

    public void ReplayLevel() => 
        LaunchLevel(SceneManager.GetActiveScene().buildIndex);
}
