using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData[] _enemies;
    [SerializeField] private Health _targetHealth;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private EnemyData _enemyData;
    private WaitForSeconds _wait;
    private Health _health;
    private int _enemyIndex = 0;

    private void Awake()
    {
        _health = GetComponent<Health>();

        Setup();
    }

    private void OnEnable() =>
        _health.Dead += Setup;

    private void OnDisable() =>
        _health.Dead -= Setup;

    private void Start() =>
        StartCoroutine(nameof(Hit));

    private IEnumerator Hit()
    {
        while (_targetHealth.HealthValue > 0 && _health.HealthValue > 0)
        {
            _targetHealth.TakeDamage(_enemyData.DamageValue);

            yield return _wait;
        }
    }

    private void Setup()
    {
        if (_enemies.Length > _enemyIndex)
        {
            _enemyData = _enemies[_enemyIndex];
            _health.SetHealth(_enemyData.HealthValue);
            _wait = new WaitForSeconds(_enemyData.AttackDelay);
            _spriteRenderer.sprite = _enemyData.Sprite;

            _enemyIndex++;
        }
    }
}
