using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private EnemyScriptableObject[] _enemies;
    [SerializeField] private Health _health;

    private EnemyScriptableObject _enemyData;
    private int _enemyIndex = 0;

    private void OnEnable() => 
        _health.Dead += Spawn;

    private void OnDisable() =>
        _health.Dead -= Spawn;

    private void Start() => 
        Spawn();

    private void Spawn()
    {
        _enemy.EnemyRenderer.Clear();

        if (_enemies.Length > _enemyIndex)
        {
            _enemyData = _enemies[_enemyIndex];

            _enemy.EnemyRenderer.DrawEnemy(_enemyData.Prefab, _enemyData.Name);

            _enemy.Setup(_enemyData.DamageValue, _enemyData.AttackDelay, _enemyData.HealthValue);

            _enemy.Resistance.Setup(_enemyData.Resistances);

            _enemyIndex++;
        }
    }
}
