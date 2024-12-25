using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _count;

    public event Action<int> CountChanged;
    public int Count => _count;

    public void AddCoins(int count)
    {
        _count += count;

        CountChanged?.Invoke(_count);
    }

    public void CheckTransaction(PowerUp powerUp)
    {
        if (_count >= powerUp.Price + powerUp.Price * powerUp.PowerUpsCount && powerUp.Cages[powerUp.Cages.Count - 1].isOn == false)
        {
            SpendMoney(powerUp.Price + powerUp.Price * powerUp.PowerUpsCount);

            powerUp.Upgrade();
        }
    }

    public void SetCount(int count)
    {
        if (Count >= 0)
            _count = count;

        CountChanged?.Invoke(_count);
    }

    private void SpendMoney(int price)
    {
        _count -= price;

        CountChanged?.Invoke(_count);
    }
}



