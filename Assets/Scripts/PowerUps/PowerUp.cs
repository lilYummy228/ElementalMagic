using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] protected string _name;
    [SerializeField] private string _description;
    [SerializeField] protected List<Toggle> _cages;

    protected int _cagesFilledCount;
    public string Description => _description;
    public int Price => _price;
    public IReadOnlyList<Toggle> Cages => _cages;

    public void Upgrade()
    {
        foreach (Toggle cage in _cages)
        {
            if (cage.isOn == false)
            {
                cage.isOn = true;

                _cagesFilledCount++;

                break;
            }
        }
    }

    [ContextMenu("Refresh upgrades")]
    public void Refresh() =>
        _cagesFilledCount = 0;
}
