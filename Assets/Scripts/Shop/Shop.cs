using Player;
using UnityEngine;
using YG;

namespace Shop
{
    public class Shop : MonoBehaviour
    {
        private const int RewardId = 1;

        [SerializeField] private Wallet _wallet;

        private int _rewardedCoinCount = 25;
        private int _firstLaunchRewardCoinCount = 35;

        private void OnEnable() =>
            YandexGame.RewardVideoEvent += AddRewardedCoins;

        private void OnDisable() =>
            YandexGame.RewardVideoEvent -= AddRewardedCoins;

        private void Start() =>
            AddFirstLaunchReward();

        public void Buy(PowerUp powerUp) =>
            _wallet.CheckTransaction(powerUp);

        public void AddRewardedCoins(int id)
        {
            if (id != RewardId)
                return;

            _wallet.AddCoins(_rewardedCoinCount);
        }

        private void AddFirstLaunchReward()
        {
            if (YandexGame.savesData.isFirstLaunch == true)
            {
                _wallet.AddCoins(_firstLaunchRewardCoinCount);
                YandexGame.savesData.isFirstLaunch = false;

                YandexGame.SaveProgress();
            }
        }
    }
}