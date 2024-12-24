using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private int _upgradeValue;
    [SerializeField] private List<Toggle> _cages;
    [SerializeField] private string _fileName;

    private SaveData _saveData = new();
    private string _path;

    public event Action<string> Upgraded;
    public int Price => _price;
    public int UpgradeValue => _upgradeValue;
    public int FilledCages { get; private set; }
    public IReadOnlyList<Toggle> Cages => _cages;

    private void Start() =>
        Upgraded?.Invoke((_price + _price * FilledCages).ToString());

    private void OnEnable() =>
        Load();

    private void OnDisable() =>
        Save();

    public void Load()
    {      
        foreach (Toggle toggle in _cages)
            toggle.isOn = false;

        _path = Path.Combine(Application.dataPath, _fileName);

        if (File.Exists(_path))
            _saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(_path));

        FilledCages = (int)_saveData.value;

        for (int i = 0; i < FilledCages; i++)
            _cages[i].isOn = true;
    }

    public void Save()
    {
        _saveData.value = FilledCages;

        File.WriteAllText(_path, JsonUtility.ToJson(_saveData));
    }

    public void Upgrade()
    {
        foreach (Toggle cage in _cages)
        {
            if (cage.isOn == false)
            {
                cage.isOn = true;

                FilledCages++;

                if (_cages[_cages.Count - 1].isOn == true)
                {
                    Upgraded?.Invoke(default);

                    return;
                }

                Upgraded?.Invoke((_price + _price * FilledCages).ToString());

                break;
            }
        }
    }
}