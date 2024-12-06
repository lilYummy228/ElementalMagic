using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementAbility : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private ElementConnector _elementConnector;
    [SerializeField] private ElementAbilityEffector _elementEffect;
    [SerializeField] private int _elementsAbilityCount = 5;
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
        if (elements.Count >= _elementsAbilityCount)
        {
            if (elements[0].TryGetComponent(out WaterElement waterElement))
                StartCoroutine(PeriodicEffect(elements.Count + PlayerPrefs.GetInt(nameof(UpgradeDamage)), _player));
            else if (elements[0].TryGetComponent(out FireElement fireElement))
                StartCoroutine(PeriodicEffect(elements.Count + PlayerPrefs.GetInt(nameof(UpgradeDamage)) * _enemy.Resistance.GetPercentValue(fireElement), _enemy));
        }
    }

    private IEnumerator PeriodicEffect<T>(float value, T gameObject) where T : MonoBehaviour
    {
        ParticleSystem particle = null;

        for (int i = 0; i < _tickCount; i++)
        {
            if (gameObject == _player)
            {
                _player.Health.Heal(value);

                if (_player.Health.CurrentHealthValue < 0)
                    break;

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
