using UnityEngine;
using YG;

public class Shop : MonoBehaviour
{
    private const int RewardId = 1;

    [SerializeField] private Wallet _wallet;

    private int _minCoinCount = 10;
    private int _maxCoinCount = 30;

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

        _wallet.AddCoins(Random.Range(_minCoinCount, _maxCoinCount));
    }
}
