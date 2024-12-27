using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public event Action<int> CountChanged;
    public int Count { get; private set; }

    public void AddCoins(int count)
    {
        Count += count;

        CountChanged?.Invoke(Count);
    }

    public void CheckTransaction(PowerUp powerUp)
    {
        if (Count >= powerUp.Price + powerUp.Price * powerUp.PowerUpsCount && powerUp.Cages[powerUp.Cages.Count - 1].isOn == false)
        {
            SpendMoney(powerUp.Price + powerUp.Price * powerUp.PowerUpsCount);

            powerUp.Upgrade();
        }
    }

    public void SetCount(int count)
    {
        if (Count >= 0)
            Count = count;

        CountChanged?.Invoke(Count);
    }

    private void SpendMoney(int price)
    {
        Count -= price;

        CountChanged?.Invoke(Count);
    }
}



