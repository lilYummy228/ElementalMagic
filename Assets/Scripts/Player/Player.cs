using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private ElementConnector _elementConnector;
    [SerializeField] private Wallet _wallet;

    public Wallet Wallet => _wallet;
    public Health Health { get; private set; }

    private void Awake() =>
        Health = GetComponent<Health>();

    private void OnEnable() =>
        _elementConnector.ElementsFilled += Hit;

    private void OnDisable() =>
        _elementConnector.ElementsFilled -= Hit;

    private void Start() => 
        Health.SetHealth(Health.CurrentHealthValue + PlayerPrefs.GetFloat(nameof(UpgradeHealth)));

    public void Hit(IReadOnlyList<Element> elements)
    {
        foreach (Element element in elements)
            element.Projectile.Init(_enemy.EnemyRenderer.EnemyTransform);

        _enemy.Health.TakeDamage(elements.Count * (elements[0].Damage + elements.Count) * _enemy.Resistance.GetPercentValue(elements[0]));
    }
}
