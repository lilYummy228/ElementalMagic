using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    private const int Multiplier = 2;

    [SerializeField] private int _price;
    [SerializeField] protected string _name;
    [SerializeField] private string _description;
    [SerializeField] protected List<Toggle> _cages;

    public event Action Upgraded;

    protected int _cagesFilledCount;
    public string Description => _description;
    public int Price => _price;
    public IReadOnlyList<Toggle> Cages => _cages;

    private void Start() => 
        ChangePrice();

    public void Upgrade()
    {
        foreach (Toggle cage in _cages)
        {
            if (cage.isOn == false)
            {
                cage.isOn = true;                

                _cagesFilledCount++;

                Upgraded?.Invoke();

                break;
            }
        }
    }

    [ContextMenu("Refresh upgrades")]
    public void Refresh() =>
        _cagesFilledCount = 0;

    private void ChangePrice()
    {
        for (int i = 0; i < _cagesFilledCount; i++)
            _price *= Multiplier;
    }
}
