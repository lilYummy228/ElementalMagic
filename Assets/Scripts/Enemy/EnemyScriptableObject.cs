using Lean.Localization;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    [SerializeField] private Transform _prefab;
    [SerializeField] private int _healthValue;
    [SerializeField] private int _damageValue;
    [SerializeField] private int _attackDelay;
    [SerializeField] private int _award;
    [Header("Localization")]
    [SerializeField] private string _russianName;
    [SerializeField] private string _englishName;
    [SerializeField] private string _turkishName;
    [Header("Resistances")]
    [SerializeField] private int _fireResistance;
    [SerializeField] private int _waterResistance;
    [SerializeField] private int _earthResistance;
    [SerializeField] private int _windResistance;

    public LeanLocalization Localization => FindObjectOfType<LeanLocalization>();
    public Transform Prefab => _prefab;
    public string Name
    {
        get
        {
            return Localization.CurrentLanguage switch
            {
                "Russian" => _russianName,
                "English" => _englishName,
                "Turkey" => _turkishName,
                _ => _russianName,
            };
        }
    }
    public int HealthValue => _healthValue;
    public int DamageValue => _damageValue;
    public int AttackDelay => _attackDelay;
    public int Award => _award;
    public IReadOnlyList<int> Resistances => new List<int>() { _fireResistance, _waterResistance, _earthResistance, _windResistance };
}
