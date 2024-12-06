using UnityEngine;

public class UpgradeGrid : PowerUp
{
    [SerializeField] private Grid _grid;

    private int _upgradeGridValue = 1;

    private void OnEnable()
    {
        _cagesFilledCount = PlayerPrefs.GetInt(_name);

        for (int i = 0; i < _cagesFilledCount; i++)
            _cages[i].isOn = true;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt(_name, _cagesFilledCount);
        PlayerPrefs.SetInt(name, _upgradeGridValue * _cagesFilledCount);
    }
}
