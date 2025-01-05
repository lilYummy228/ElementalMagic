using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementAbility : MonoBehaviour
{
    private const float Divider = 1.5f;

    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private ElementConnector _elementConnector;
    [SerializeField] private ElementAbilityEffector _elementEffect;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private int _elementsAbilityCount = 7;
    [SerializeField] private int _tickRate;
    [SerializeField] private int _tickCount;

    private WaitForSeconds _tick;
    private List<int> _resistances = new();
    private List<int> _windEffectResistances = new();

    private void Awake() =>
        _tick = new(_tickRate);

    private void OnEnable()
    {
        _enemySpawner.EnemySpawned += StopAllEffects;
        _elementConnector.ElementsFilled += Effect;
    }

    private void OnDisable()
    {
        _enemySpawner.EnemySpawned -= StopAllEffects;
        _elementConnector.ElementsFilled -= Effect;
    }

    private void StopAllEffects()
    {
        StopAllCoroutines();
        _elementEffect.StopAllEffects();
    }

    private void Effect(IReadOnlyList<Element> elements)
    {
        if (elements.Count >= _elementsAbilityCount)
        {
            if (elements[0].TryGetComponent(out WaterElement waterElement))
                StartCoroutine(PeriodicEffect(elements.Count + elements.Count, _player));
            else if (elements[0].TryGetComponent(out FireElement fireElement))
                StartCoroutine(PeriodicEffect((elements[0].Damage + elements.Count) * _enemy.Resistance.GetPercentValue(fireElement), _enemy));
            else if (elements[0].TryGetComponent(out EarthElement earthElement))
                StartCoroutine(EarthEffect(elements.Count / Divider));
            else if (elements[0].TryGetComponent(out WindElement windElement))
                StartCoroutine(WindEffect(elements.Count / Divider));
        }
    }

    private IEnumerator EarthEffect(float value)
    {
        int damage = _enemy.Damage;

        _enemy.SetDamage(default);

        _elementEffect.PlayEffect(_elementEffect.EarthEffect);

        yield return new WaitForSeconds(value);

        _enemy.SetDamage(damage);

        _elementEffect.EarthEffect.Stop();
    }

    private IEnumerator WindEffect(float value)
    {
        _resistances.Clear();
        _windEffectResistances.Clear();

        foreach (var resist in _enemy.Resistance.Resistances)
        {
            _resistances.Add(resist.Value);

            if (resist.Value > 0)
                _windEffectResistances.Add(default);
            else
                _windEffectResistances.Add(resist.Value);
        }

        _enemy.Resistance.Setup(_windEffectResistances);

        _elementEffect.PlayEffect(_elementEffect.WindEffect);

        yield return new WaitForSeconds(value);

        _enemy.Resistance.Setup(_resistances);

        _elementEffect.WindEffect.Stop();
    }

    private IEnumerator PeriodicEffect<T>(float value, T gameObject) where T : MonoBehaviour
    {
        ParticleSystem particle = null;

        for (int i = 0; i < _tickCount; i++)
        {
            if (gameObject == _player)
            {
                if (_player.Health.CurrentHealthValue < 0)
                    break;

                _player.Health.Heal(value);

                particle = _elementEffect.WaterEffect;
                _elementEffect.PlayEffect(particle);
            }
            else if (gameObject == _enemy)
            {
                _enemy.Health.TakeDamage(value);

                if (_enemy.Health.CurrentHealthValue < 0)
                    break;

                particle = _elementEffect.FireEffect;
                _elementEffect.PlayEffect(particle);
            }

            yield return _tick;
        }

        particle?.Stop();
    }
}
