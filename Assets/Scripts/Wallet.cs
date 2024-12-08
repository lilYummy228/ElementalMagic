using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _count;

    public event Action<int> CountChanged;

    public int Count => _count;

    public void Add(int count)
    {
        _count += count;

        CountChanged?.Invoke(_count);
    }

    public void CheckTransaction(PowerUp powerUp)
    {
        if (_count >= powerUp.Price && powerUp.Cages[powerUp.Cages.Count - 1].isOn == false)
        {
            SpendMoney(powerUp.Price);

            powerUp.Upgrade();
        }
    }

    private void SpendMoney(int price)
    {
        _count -= price;

        CountChanged?.Invoke(_count);
    }
}
