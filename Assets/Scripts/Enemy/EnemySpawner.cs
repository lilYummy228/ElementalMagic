using System;
using UnityEngine;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] protected Enemy _enemy;
        [SerializeField] protected EnemyScriptableObject[] _enemies;
        [SerializeField] private Health.Health _health;

        protected EnemyScriptableObject _enemyData;
        private int _enemyIndex = 0;

        public event Action AllEnemiesDied;
        public event Action EnemySpawned;

        private void OnEnable()
        {
            _health.Dead += Spawn;
            _health.Dead += PayAward;
        }

        private void OnDisable()
        {
            _health.Dead -= Spawn;
            _health.Dead -= PayAward;
        }

        protected void OnEnemySpawned() =>
            EnemySpawned?.Invoke();

        public virtual void Spawn()
        {
            if (_enemy.Health.CurrentHealthValue <= 0 || _enemyIndex == 0)
            {
                _enemy.EnemyRenderer.Clear();

                if (_enemies.Length > _enemyIndex)
                {
                    OnEnemySpawned();

                    _enemyData = _enemies[_enemyIndex];

                    _enemy.EnemyRenderer.DrawEnemy(_enemyData.Prefab, _enemyData.Name);

                    _enemy.Setup(_enemyData.DamageValue, _enemyData.AttackDelay, _enemyData.HealthValue);

                    _enemy.Resistance.Setup(_enemyData.Resistances);

                    _enemyIndex++;

                    return;
                }

                AllEnemiesDied?.Invoke();
            }
        }

        public void RefreshAttack()
        {
            _enemy.Counter.StartCooldown(_enemyData.AttackDelay);
            _enemy.StartHit();
        }

        private void PayAward() =>
            _enemy.PayAward(_enemyData.Award);
    }
}