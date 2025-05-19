using Shop;
using Elements;
using System.Collections.Generic;
using UnityEngine;
using YG;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Enemy.Enemy _enemy;
        [SerializeField] private ElementConnector _elementConnector;
        [SerializeField] private Wallet _wallet;
        [SerializeField] private Health.Health _health;
        [SerializeField] private PowerUp _powerUp;

        public Wallet Wallet => _wallet;
        public Health.Health Health => _health;

        public float HealthContinueValue { get; private set; } = 250f;

        private void OnEnable()
        {
            _enemy.EnemyCoinsCollected += AddCoins;
            _elementConnector.ElementsFilled += Hit;
        }

        private void OnDisable()
        {
            _enemy.EnemyCoinsCollected -= AddCoins;
            _elementConnector.ElementsFilled -= Hit;
        }

        private void Start() =>
            Health.SetHealth(Health.CurrentHealthValue + YandexGame.savesData.healthPowerUps * _powerUp.UpgradeValue);

        public void Hit(IReadOnlyList<Element> elements)
        {
            foreach (Element element in elements)
                element.Projectile.Init(_enemy.EnemyRenderer.EnemyTransform);

            _enemy.Health.TakeDamage(elements.Count * (elements[0].Damage + elements.Count) * _enemy.Resistance.GetPercentValue(elements[0]));
        }

        private void AddCoins(int count)
        {
            _wallet.AddCoins(count);
        }
    }
}