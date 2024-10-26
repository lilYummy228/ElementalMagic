using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _healthValue;
    [SerializeField] private int _damageValue;
    [SerializeField] private int _attackDelay;

    public Sprite Sprite => _sprite;
    public int HealthValue => _healthValue;
    public int DamageValue => _damageValue;
    public int AttackDelay => _attackDelay;
}
