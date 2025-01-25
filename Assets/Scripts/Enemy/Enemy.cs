using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemyRenderer _renderer;
    [SerializeField] private Health _health;
    [SerializeField] private EnemyResistance _resistance;
    [SerializeField] private Counter _counter;

    public event Action<int> EnemyCoinsCollected;

    private WaitForSeconds _delay;
    private Coroutine _coroutine;
    private string _name;
    private int _damage;

    public Counter Counter => _counter;
    public EnemyRenderer EnemyRenderer => _renderer;
    public Health Health => _health;
    public EnemyResistance Resistance => _resistance;
    public int Damage => _damage;

    public void StartHit()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(nameof(Hit));
    }

    public void Setup(int damage, int attackDelay, int healthValue)
    {
        _delay = new(attackDelay);
        _counter.StartCooldown(attackDelay);

        SetDamage(damage);

        _health.SetHealth(healthValue);
        _health.StartDeathControl();

        StartHit();
    }

    public void SetDamage(int damage)
    {
        if (damage >= 0)
            _damage = damage;
    }

    public void PayAward(int award) => 
        EnemyCoinsCollected?.Invoke(award);

    private IEnumerator Hit()
    {
        while (_health.CurrentHealthValue > 0)
        {
            yield return _delay;

            _player.Health.TakeDamage(_damage);
        }
    }
}
