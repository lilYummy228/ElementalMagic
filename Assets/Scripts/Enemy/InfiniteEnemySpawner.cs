public class InfiniteEnemySpawner : EnemySpawner
{
    private bool _isFirstEnemy = true;
    private int _enemyId;

    public override void Spawn()
    {
        int tempEnemyId = _enemyId;

        while (tempEnemyId == _enemyId)
            _enemyId = UnityEngine.Random.Range(0, _enemies.Length);

        _enemy.EnemyRenderer.Clear();

        if (_isFirstEnemy == false)
            _enemy.PayAward(_enemyData.Award);

        OnEnemySpawned();

        _enemyData = _enemies[_enemyId];

        _enemy.EnemyRenderer.DrawEnemy(_enemyData.Prefab, _enemyData.Name);

        _enemy.Setup(_enemyData.DamageValue, _enemyData.AttackDelay, _enemyData.HealthValue);

        _enemy.Resistance.Setup(_enemyData.Resistances);

        _isFirstEnemy = false;
    }
}
