using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Min(0)] private float _currentHealthValue;

    public float MaxHealthValue { get; private set; }
    public float CurrentHealthValue => _currentHealthValue;

    public event Action HealthValueChanged;
    public event Action Dead;

    private void Start() =>
        StartDeathControl();

    public void TakeDamage(float damageValue)
    {
        _currentHealthValue -= damageValue;

        if (_currentHealthValue < 0)
            _currentHealthValue = 0;

        HealthValueChanged?.Invoke();
    }

    public void Heal(float healValue)
    {
        if (_currentHealthValue > 0 && _currentHealthValue < MaxHealthValue)
            _currentHealthValue += healValue;

        if (_currentHealthValue > MaxHealthValue)
            _currentHealthValue = MaxHealthValue;

        HealthValueChanged?.Invoke();
    }

    public void SetHealth(float healthValue)
    {
        if (healthValue > 0)
        {
            _currentHealthValue = healthValue;
            MaxHealthValue = healthValue;

            HealthValueChanged?.Invoke();
        }
    }

    public void StartDeathControl() =>
        StartCoroutine(nameof(ControlDeath));

    private IEnumerator ControlDeath()
    {
        yield return new WaitUntil(() => _currentHealthValue <= 0);

        Dead?.Invoke();
    }
}
