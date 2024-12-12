using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private ElementConnector _elementConnector;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Health _health;
    [SerializeField] private PowerUp _powerUp;

    public Wallet Wallet => _wallet;
    public Health Health => _health;       

    private void OnEnable()
    {
        _elementConnector.ElementsFilled += Hit;
        _powerUp.Setup();
    }

    private void OnDisable()
    {
        _elementConnector.ElementsFilled -= Hit;
        _powerUp.Save();
    }

    private void Start() => 
        Health.SetHealth(Health.CurrentHealthValue + _powerUp.FilledCages * _powerUp.UpgradeValue);

    public void Hit(IReadOnlyList<Element> elements)
    {
        foreach (Element element in elements)
            element.Projectile.Init(_enemy.EnemyRenderer.EnemyTransform);

        _enemy.Health.TakeDamage(elements.Count * (elements[0].Damage + elements.Count) * _enemy.Resistance.GetPercentValue(elements[0]));
    }
}
