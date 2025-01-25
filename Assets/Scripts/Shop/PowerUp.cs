using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    private const string MaximumUpgrade = "Max";

    [SerializeField] private int _price;
    [SerializeField] private int _upgradeValue;
    [SerializeField] private List<Toggle> _cages;

    public event Action<string> Upgraded;
    public int Price => _price;
    public int UpgradeValue => _upgradeValue;
    public int PowerUpsCount { get; private set; }
    public IReadOnlyList<Toggle> Cages => _cages;

    private void Start()
    {
        Setup();

        Upgraded?.Invoke(GetPrice());
    }

    public void Setup()
    {      
        foreach (Toggle toggle in _cages)
            toggle.isOn = false;

        for (int i = 0; i < PowerUpsCount; i++)
            _cages[i].isOn = true;
    }

    public void SetPowerUpsCount(int count) => 
        PowerUpsCount = count;

    public void Upgrade()
    {
        foreach (Toggle cage in _cages)
        {
            if (cage.isOn == false)
            {
                cage.isOn = true;

                PowerUpsCount++;

                Upgraded?.Invoke(GetPrice());

                break;
            }
        }
    }

    private string GetPrice()
    {
        if (_cages[_cages.Count - 1].isOn == true)
        {
            Upgraded?.Invoke(default);

            return MaximumUpgrade;
        }

        return (_price + _price * PowerUpsCount).ToString();
    }
}