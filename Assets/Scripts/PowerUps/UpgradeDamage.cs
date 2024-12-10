using System.Collections.Generic;
using UnityEngine;

public class UpgradeDamage : PowerUp
{
    private int _upgradeDamageValue = 2;

    private void OnEnable()
    {
        _cagesFilledCount = PlayerPrefs.GetInt(_name);

        for (int i = 0; i < _cagesFilledCount; i++)
            _cages[i].isOn = true;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt(_name, _cagesFilledCount);
        PlayerPrefs.SetFloat(name, _upgradeDamageValue * _cagesFilledCount);
    }
}
