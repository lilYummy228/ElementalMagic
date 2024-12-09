using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    [SerializeField] private Transform _prefab;
    [SerializeField] private string _name;
    [SerializeField] private int _healthValue;
    [SerializeField] private int _damageValue;
    [SerializeField] private int _attackDelay;
    [SerializeField] private int _award;
    [Header("Resistances")]
    [SerializeField] private int _fireResistance;
    [SerializeField] private int _waterResistance;
    [SerializeField] private int _earthResistance;
    [SerializeField] private int _windResistance;

    public Transform Prefab => _prefab;
    public string Name => _name;
    public int HealthValue => _healthValue;
    public int DamageValue => _damageValue;
    public int AttackDelay => _attackDelay;
    public int Award => _award;
    public IReadOnlyList<int> Resistances => new List<int>() { _fireResistance, _waterResistance, _earthResistance, _windResistance};
}
