using UnityEngine;
using YG;

public class Shop : MonoBehaviour
{
    private const int RewardId = 1;

    [SerializeField] private Wallet _wallet;

    private int _rewardedCoinCount = 25;
    private int _firstLaunchRewardCoinCount = 35;

    private void Start()
    {
        AddFirstLaunchReward();
    }

    private void AddFirstLaunchReward()
    {
        if (YandexGame.savesData.IsFirstLaunch == true)
        {
            _wallet.AddCoins(_firstLaunchRewardCoinCount);
            YandexGame.savesData.IsFirstLaunch = false;

            YandexGame.SaveProgress();
        }
    }

    private void OnEnable() => 
        YandexGame.RewardVideoEvent += AddRewardedCoins;

    private void OnDisable() => 
        YandexGame.RewardVideoEvent -= AddRewardedCoins;

    public void Buy(PowerUp powerUp) => 
        _wallet.CheckTransaction(powerUp);

    public void AddRewardedCoins(int id)
    {
        if (id != RewardId)
            return;

        _wallet.AddCoins(_rewardedCoinCount);
    }
}
