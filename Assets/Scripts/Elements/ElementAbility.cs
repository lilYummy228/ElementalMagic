using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementAbility : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private ElementConnector _elementConnector;
    [SerializeField] private ElementAbilityEffector _elementEffect;
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
                StartCoroutine(PeriodicEffect(elements.Count, _player));
            else if (elements[0].TryGetComponent(out FireElement fireElement))
                StartCoroutine(PeriodicEffect(elements.Count, _enemy));
        }
    }

    private IEnumerator PeriodicEffect<T>(float value, T gameObject) where T : MonoBehaviour
    {
        ParticleSystem particle = null;

        for (int i = 0; i < _tickCount; i++)
        {
            if (gameObject == _player)
            {
                if (IsAbleToEffect(value, _player.Health.Heal, _player.Health) == false)
                    break;
            }
            else if (gameObject == _enemy)
            {
                if (IsAbleToEffect(value, _enemy.Health.TakeDamage, _enemy.Health) == false)
                    break;
                
                particle = _elementEffect.FireEffect;
                _elementEffect.PlayEffect(particle);
            }

            yield return _tick;
        }

        particle?.Stop();
    }

    private bool IsAbleToEffect(float value, Action<float> effect, Health health)
    {
        if (health.CurrentHealthValue - value > 0)
        {
            effect.Invoke(value);
            return true;
        }
        else
        {
            return false;
        }
    }
}
