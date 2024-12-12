using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private string _description;
    [SerializeField] private int _upgradeValue;
    [SerializeField] private string _fileName;
    [SerializeField] private List<Toggle> _cages;

    private SaveData _saveData = new();
    private string _path;

    public event Action Upgraded;
    public string Description => _description;
    public int Price => _price;
    public int UpgradeValue => _upgradeValue;
    public int FilledCages { get; private set; }
    public IReadOnlyList<Toggle> Cages => _cages;
    
    private void OnEnable() => 
        Setup();

    private void OnDisable() => 
        Save();

    private void Start() =>
        ChangePrice();

    public void Setup()
    {
        _path = Path.Combine(Application.dataPath, _fileName);

        if (File.Exists(_path))
            _saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(_path));

        FilledCages = Convert.ToInt32(_saveData.value);

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

                ChangePrice();

                Upgraded?.Invoke();

                break;
            }
        }
    }

    public void ChangePrice()
    {
        for (int i = 0; i < FilledCages; i++)
            _price += _price;
    }    
}
