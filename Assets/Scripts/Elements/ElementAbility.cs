using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementAbility : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private ElementConnector _elementConnector;
    [SerializeField] private int _elementsCountEffect = 5;
    [SerializeField] private int _tickRate;
    [SerializeField] private int _tickCount;

    private WaitForSeconds _tick;

    private void Awake() =>
        _tick = new WaitForSeconds(_tickRate);

    private void OnEnable() =>
        _elementConnector.ElementsFilled += Effect;

    private void OnDisable() =>
        _elementConnector.ElementsFilled -= Effect;

    private void Effect(IReadOnlyList<Element> elements)
    {
        if (elements.Count >= _elementsCountEffect)
        {
            if (elements[0].TryGetComponent(out WaterElement waterElement))
                StartCoroutine(PeriodicEffect(elements.Count, _player.Health.Heal));
            else if (elements[0].TryGetComponent(out FireElement fireElement))
                StartCoroutine(PeriodicEffect(elements.Count, _enemy.Health.TakeDamage));
        }
    }

    private IEnumerator PeriodicEffect(float value, Action<float> action)
    {
        for (int i = 0; i < _tickCount; i++)
        {
            action.Invoke(value);

            yield return _tick;
        }
    }
}
