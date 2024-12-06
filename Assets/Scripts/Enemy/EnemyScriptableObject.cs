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

    [SerializeField] private List<int> _resistances = new List<int>();

    [SerializeField] private int _award;

    public Transform Prefab => _prefab;
    public string Name => _name;
    public int HealthValue => _healthValue;
    public int DamageValue => _damageValue;
    public int AttackDelay => _attackDelay;
    public IReadOnlyList<int> Resistances => _resistances;
    public int Award => _award;
}
