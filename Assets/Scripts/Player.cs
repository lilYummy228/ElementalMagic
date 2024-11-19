using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private ElementConnector _elementConnector;

    public Health Health { get; private set; }

    private void Awake() =>
        Health = GetComponent<Health>();

    private void Start() =>
        Health.SetHealth(Health.CurrentHealthValue);

    private void OnEnable() =>
        _elementConnector.ElementsFilled += Hit;

    private void OnDisable() =>
        _elementConnector.ElementsFilled -= Hit;

    public void Hit(IReadOnlyList<Element> elements)
    {
        foreach (Element element in elements)
            element.Projectile.Init(_enemy.EnemyRenderer.EnemyPosition);

        _enemy.Health.TakeDamage(elements.Count * elements[0].Damage * _enemy.Resistance.GetPercentValue(elements[0]));
    }
}
