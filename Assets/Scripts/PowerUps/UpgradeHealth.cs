using UnityEngine;

public class UpgradeHealth : PowerUp
{
    private float _healthUpgradeValue = 250f;

    private void OnEnable()
    {
        _cagesFilledCount = PlayerPrefs.GetInt(_name);

        for (int i = 0; i < _cagesFilledCount; i++)
            _cages[i].isOn = true;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt(_name, _cagesFilledCount);
        PlayerPrefs.SetFloat(name, _healthUpgradeValue * _cagesFilledCount);
    }
}
